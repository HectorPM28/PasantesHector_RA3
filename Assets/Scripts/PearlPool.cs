using System.Collections.Generic;
using UnityEngine;

public class PearlPool : MonoBehaviour
{
    public static PearlPool Instance;

    [SerializeField] private GameObject pearlPrefab;
    [SerializeField] private int initialSize = 20;

    private Stack<GameObject> freeObjects = new Stack<GameObject>();
    
    void Awake()
    {
        for (int i = 0; i < initialSize; ++i)
        {
            freeObjects.Push(CreateNewObject());
        }

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public GameObject CreateNewObject()
    {
        GameObject newPearl = Instantiate(pearlPrefab, transform);
        newPearl.SetActive(false);
        return newPearl;
    }

    public GameObject GetObject(Vector3 position, Vector2 direction, float speed)
    {
        GameObject objectToUse;

        if (freeObjects.Count > 0)
        {
            objectToUse = freeObjects.Pop();
        }
        else
        {
            objectToUse = CreateNewObject();
        }

        objectToUse.transform.position = position;
        objectToUse.SetActive(true);

        Rigidbody2D rb = objectToUse.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;

        return objectToUse;
    }
    public void ReturnObject(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        freeObjects.Push(objectToReturn);
    }
}
