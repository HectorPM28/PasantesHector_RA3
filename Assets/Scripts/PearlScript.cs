using UnityEngine;

public class PearlScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameEvents.PlayerDeath();
            PearlPool.Instance.ReturnObject(gameObject);
        }
        else if(collision.CompareTag("Terrain"))
        {
            PearlPool.Instance.ReturnObject(gameObject);
        }
    }
}
