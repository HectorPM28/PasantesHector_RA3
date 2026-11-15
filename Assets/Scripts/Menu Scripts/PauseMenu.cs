using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, InputSystem_Actions.IPauseOptionsActions
{
    private InputSystem_Actions inputActions;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private List<int> bannedScenes = new List<int>();

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.PauseOptions.SetCallbacks(this);
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentLevel = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pausePanel.SetActive(false);
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentLevel = 0;
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!bannedScenes.Contains(SceneManager.GetActiveScene().buildIndex))
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);//!pausePanel.activeSelf);
            }
        }
    }
}
