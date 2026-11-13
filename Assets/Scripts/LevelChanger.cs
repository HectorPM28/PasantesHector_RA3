using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private int LevelId;
    [SerializeField] private int PlayerTeleportId;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.CanTeleport)
        {
            GameManager.Instance.CanTeleport = false;
            GameEvents.LevelWin(LevelId);
            GameEvents.PlayerTeleport(PlayerTeleportId);
            StartCoroutine(ReactivateTeleport());
        }
	}

    private IEnumerator ReactivateTeleport()
    {
        yield return new WaitForSeconds(1f);

        GameManager.Instance.CanTeleport = true;
    }
}
