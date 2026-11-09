using UnityEngine;

public class SeashellScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector2 bulletDirection;

    public void CreatePearl()
    {
        PearlPool.Instance.GetObject(spawnPoint.position, bulletDirection);
    }

}
