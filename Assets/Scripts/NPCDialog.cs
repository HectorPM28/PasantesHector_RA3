using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialog : MonoBehaviour, InputSystem_Actions.INPCActions
{
    [SerializeField] private List<string> dialogs = new List<string>();
    public GameObject DialogBubble;
    public TextMeshProUGUI text;
    private bool canSpeak = false;
    private int currentText = 0;
    private InputSystem_Actions Input;


    private void Awake()
    {
        Input = new InputSystem_Actions();
        Input.NPC.SetCallbacks(this);
    }
    private void OnEnable()
    {
        Input.Enable();
    }
    private void OnDisable()
    {
        Input.Disable();
    }

    private void Start()
    {
        text.text = dialogs[currentText];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canSpeak = true;
            DialogBubble.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canSpeak = false;
            DialogBubble.SetActive(false);
            currentText = 0;
            text.text = dialogs[currentText];
        }
    }

    public void OnPassDialog(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (currentText >= dialogs.Count - 1 || !canSpeak) return;

            currentText++;
            text.text = dialogs[currentText];
        }
    }
}
