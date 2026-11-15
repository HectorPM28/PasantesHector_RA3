using UnityEngine;

public class PearlScript : MonoBehaviour
{
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
    private void Update()
    {
        if (OutOfCamera())
        {
            PearlPool.Instance.ReturnObject(gameObject);
        }
    }

    private bool OutOfCamera()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);

        return screenPosition.x < 0f || screenPosition.x > 1f ||
               screenPosition.y < 0f || screenPosition.y > 1f;
    }
}
