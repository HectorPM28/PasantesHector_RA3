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
}
