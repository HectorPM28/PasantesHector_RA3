using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private Vector3 newCameraPosition;
    [SerializeField] private float newCameraSize;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.CanTeleport)
        {
            GameManager.Instance.ChangeCamera(newCameraPosition, newCameraSize);
        }
    }
}
