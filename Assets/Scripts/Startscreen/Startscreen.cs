using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startscreen : MonoBehaviour
{

    private StartOrQuitInput input;

    private GameObject startscreen;
    private Text[] text;
    private int active;
    private int headingSize;
    private int textSize;

    private void Awake()
    {
        input = new StartOrQuitInput();
    }

    void Start()
    {
        init();
        InputOn();
    }
    private void OnEnable()
    {
        input.Enable();
        init();
        InputOn();
    }
    private void OnDisable()
    {
        input.Disable();
        InputOff();
    }
    private void init()
    {
        startscreen = GameObject.Find("Startscreen");
        text = startscreen.GetComponentsInChildren<Text>();
        active = 1;
        text[active].color = Color.yellow;
    }

    void OnGUI()
    {
        headingSize = (Screen.width + Screen.height) / 15;
        textSize = (Screen.width + Screen.height) / 25;

        text[0].fontSize = (int)headingSize;
        text[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[0].GetComponent<RectTransform>().anchoredPosition.x, -0.2f * Screen.height);

        for (int i = 1; i < text.Length; i++)
        {
            text[i].fontSize = (int)textSize;
            text[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.2f * i - 0.3f) * Screen.height);
        }
    }

    public void InputOn()
    {
        input.StartOrQuit.Up.started += upAndDown;
        input.StartOrQuit.Down.started += upAndDown;
        input.StartOrQuit.Select.started += select;
    }
    public void InputOff()
    {
        input.StartOrQuit.Up.started -= upAndDown;
        input.StartOrQuit.Down.started -= upAndDown;
        input.StartOrQuit.Select.started -= select;
    }

    private void upAndDown(InputAction.CallbackContext obj)
    {
        text[active].color = Color.white;
        active = (active == 1) ? 2 : 1;
        text[active].color = Color.yellow;
    }

    private void select(InputAction.CallbackContext obj)
    {
        if (active == 1)
        {
            input.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Application.Quit();
        }
    }
}
