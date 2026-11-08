using UnityEngine;

public class SeashellScript : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    public void CreatePearl()
    {
        PearlPool.Instance.GetObject(spawnPoint.position);
    }

}
