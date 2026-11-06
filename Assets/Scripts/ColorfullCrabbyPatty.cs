using UnityEngine;

public class ColorfullCrabbyPatty : MonoBehaviour
{
    private SpriteRenderer sp;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.color = GetColor();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            sr.color = GetColor();
            Destroy(gameObject);
        }
    }
    private Color GetColor()
    {
        float randomR = Random.Range(0f, 1f);
        float randomG = Random.Range(0f, 1f);
        float randomB = Random.Range(0f, 1f);

        Color color = new Color(randomR, randomG, randomB);

        return color;
    }
}
