using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public List<Vector3> playerPositions = new List<Vector3>();
	public List<Vector3> playerStartingPositions = new List<Vector3>();

    public bool CanTeleport = true;
    public int currentLevel = 0;


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
		DontDestroyOnLoad(this);
    }
    private void OnEnable()
    {
        GameEvents.OnLevelWin += ChangeLevel;
    }
    private void OnDisable()
    {
        GameEvents.OnLevelWin -= ChangeLevel;
    }
    private void ChangeLevel(int level)
	{
		currentLevel = level;
	}
	public void ChangeCamera(Vector3 position, float size)
	{
		Camera.main.transform.position = position;
		Camera.main.orthographicSize = size;
	}
}
