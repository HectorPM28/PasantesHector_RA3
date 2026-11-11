using Unity.VisualScripting;
using UnityEngine;

public class SeashellScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2 bulletDirection;
    [SerializeField] private float speed;

    public void CreatePearl()
    {
        PearlPool.Instance.GetObject(spawnPoint.position, bulletDirection, speed);
    }

}
