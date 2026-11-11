using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

    public List<Vector3> cameraPositions = new List<Vector3>();
	public List<Vector3> playerPositions = new List<Vector3>();

    public bool CanTeleport = true;
    public int currentLevel = 0;

	private float initialCameraSize = 5f;

    private void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		Camera.main.orthographicSize = initialCameraSize;
    }
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
        Camera.main.transform.position = cameraPositions[currentLevel];
    }

	private void ChangeLevel(int level)
	{
		Camera.main.orthographicSize = initialCameraSize;
		Camera.main.transform.position = cameraPositions[level];
	}
	public void ChangeCamera(Vector3 position, float size)
	{
        Camera.main.transform.position = position;
        Camera.main.orthographicSize = size;
    }
}
