using System;
using UnityEngine;

public static class GameEvents
{
	public static event Action OnPlayerDeath;

	public static void PlayerDeath()
	{
		OnPlayerDeath?.Invoke();
	}
}
