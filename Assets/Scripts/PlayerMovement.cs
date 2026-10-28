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

        rb.gravityScale *= -1;
        sprite.flipY = !sprite.flipY;
        isMidAir = !isMidAir;
        animator.SetBool("isMidAir", isMidAir);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();

        transform.Translate(move * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 move = Input.Patrick.Movement.ReadValue<Vector2>();

		transform.Translate(move * speed * Time.deltaTime);
	}
}
