using UnityEngine;
using UnityEngine.UI;

public class ParallaxScript : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier = 0.5f;
    private RawImage parallaxMaterial;
    private float lastPlayerX;
    [SerializeField] private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parallaxMaterial = GetComponent<RawImage>();
        lastPlayerX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float deltax = player.position.x - lastPlayerX;

        Rect currentRect = parallaxMaterial.uvRect;
        currentRect.x += deltax * parallaxMultiplier;
        parallaxMaterial.uvRect = currentRect;

        lastPlayerX = player.position.x;
    }
}
