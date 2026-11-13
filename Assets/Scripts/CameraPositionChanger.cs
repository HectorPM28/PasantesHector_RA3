using System.Collections.Generic;
using UnityEngine;

public class CameraPositionChanger : MonoBehaviour
{
    public List<Vector3> cameraPositions = new List<Vector3>();
    private float initialCameraSize = 5f;

    private void OnEnable()
    {
        GameEvents.OnLevelWin += ChangeLevel;
    }
    private void OnDisable()
    {
        GameEvents.OnLevelWin -= ChangeLevel;
    }

    void Start()
    {
        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = cameraPositions[GameManager.Instance.currentLevel];
    }

    private void ChangeLevel(int level)
    {
        Camera.main.orthographicSize = initialCameraSize;
        Camera.main.transform.position = cameraPositions[level];
    }
}
