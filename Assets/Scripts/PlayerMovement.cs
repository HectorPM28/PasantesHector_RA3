using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, InputSystem_Actions.IPatrickActions
{
    [SerializeField] private float speed = 5f;

    private InputSystem_Actions Input;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    private bool isMidAir = false;
    private bool isDead = false;
    private Vector2 moveDirection;

    private void Awake()
    {
        Input = new InputSystem_Actions();
        Input.Patrick.SetCallbacks(this);
    }
    private void OnEnable()
    {
        Input.Enable();
    }
    private void OnDisable()
    {
        Input.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    public void OnChangeGravity(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //rb.gravityScale *= -1;
        //sprite.flipY = !sprite.flipY;
        //isMidAir = !isMidAir;
        //animator.SetBool("isMidAir", isMidAir);
        DieSequence();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        if(isDead) return;

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

    void FixedUpdate()
    {
        if (isDead) return;

        rb.linearVelocityX = moveDirection.x * speed;
    }

    private void DieSequence()
    {
        isDead = true;
		animator.SetBool("isHit", true);
		if (sprite.flipX == true)
        {
            rb.AddForce(new Vector2(-5f, 10f), ForceMode2D.Impulse);
        }
        else
        {
			rb.AddForce(new Vector2(5f, 10f), ForceMode2D.Impulse);
		}
    }
}
