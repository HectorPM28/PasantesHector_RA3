using System;
using UnityEngine;

public static class GameEvents
{
	public static event Action OnPlayerDeath;
	public static event Action<int> OnLevelWin;

	public static event Action<int> OnPlayerTeleport;

	public static void PlayerDeath()
	{
		OnPlayerDeath?.Invoke();
	}
    public static void LevelWin(int level)
	{
		OnLevelWin?.Invoke(level);
	}

	public static void PlayerTeleport(int teleportId)
	{
		OnPlayerTeleport?.Invoke(teleportId);
	}
}
