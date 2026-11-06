using UnityEngine;

public class SeashellScript : MonoBehaviour
{
    public GameObject pearlPrefab;

    public void CreatePearl()
    {
        Instantiate(pearlPrefab);
    }
}
