using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, InputSystem_Actions.IPatrickActions
{
    [SerializeField] private float speed = 5f;
	public float rayLength = 1f;
	public LayerMask groundLayer;

	private InputSystem_Actions Input;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private Collider2D collider;

    private bool isDead = false;
    private bool isGrounded;
    private Vector2 moveDirection;

    private void Awake()
    {
        Input = new InputSystem_Actions();
        Input.Patrick.SetCallbacks(this);
    }
    private void OnEnable()
    {
        Input.Enable();
        GameEvents.OnPlayerDeath += DieSequence;
		GameEvents.OnPlayerTeleport += TeleportPlayer;
    }
    private void OnDisable()
    {
        Input.Disable();
        GameEvents.OnPlayerDeath -= DieSequence;
        GameEvents.OnPlayerTeleport -= TeleportPlayer;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

        transform.position = GameManager.Instance.playerStartingPositions[GameManager.Instance.currentLevel];

    }
    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (!context.performed || !isGrounded) return;

        rb.gravityScale *= -1;
        rayLength *= -1;
        sprite.flipY = !sprite.flipY;
        collider.offset *= -1;

        AudioManager.Instance.PlaySFX(0);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if(isDead) return;

		isGrounded = IsGrounded();

		animator.SetBool("isMidAir", !isGrounded);

		switch (moveDirection.x)
        {
            case > 0:
                sprite.flipX = true;
                animator.SetBool("isRunning", true);
                break;
            case < 0:
                sprite.flipX = false;
                animator.SetBool("isRunning", true);
                break;
            case 0:
                animator.SetBool("isRunning", false);
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Trap") || collision.collider.CompareTag("Enemy"))
        {
            GameEvents.PlayerDeath();
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        rb.linearVelocityX = moveDirection.x * speed;
    }

    private void DieSequence()
    {
        AudioManager.Instance.PlaySFX(1);

        isDead = true;
		animator.SetBool("isHit", true);

        int xDirection = sprite.flipX ? 1 : -1;
        int yDirection = rb.gravityScale > 0 ? 1 : -1;

        rb.AddForce(new Vector2(-5f * xDirection, 10f * yDirection), ForceMode2D.Impulse);

        StartCoroutine(ChangeDeathScreen());
	}
	bool IsGrounded()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);

		return hit.collider != null;
	}

    private void TeleportPlayer(int level)
    {
        transform.position = GameManager.Instance.playerPositions[level];
    }
    private IEnumerator ChangeDeathScreen()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(2);
    }
}
