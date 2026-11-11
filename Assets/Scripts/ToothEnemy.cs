using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class ToothEnemy : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        switch (direction.x)
        {
            case > 0:
                sprite.flipX = true;
                break;
            case < 0:
                sprite.flipX = false;
                break;
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DirectionChanger"))
        {
            direction = -direction;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            direction = -direction;
        }
    }
}
