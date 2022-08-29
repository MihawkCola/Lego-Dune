using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndscreenScript : MonoBehaviour
{
    private StartOrQuitInput input;

    private GameObject endscreen;
    private Text[] text;
    private int active;
    private int headingSize;
    private int textSize;
    private int imageSize;

    private void Awake()
    {
        input = new StartOrQuitInput();
    }
    private void OnEnable()
    {
        input.Enable();
        init();
        InputOn();
    }
    public void InputOn()
    {
        input.StartOrQuit.Up.started += upAndDown;
        input.StartOrQuit.Down.started += upAndDown;
        input.StartOrQuit.Select.started += select;
    }

    private void init()
    {
        endscreen = GameObject.Find("Endscreen");
        text = endscreen.GetComponentsInChildren<Text>();
        endscreen.GetComponentsInChildren<Text>()[2].text = GameObject.Find("HUD").GetComponent<CoinsScript>().getCoinAmount().ToString();
        active = 3;
        text[active].color = Color.yellow;
    }
    public StartOrQuitInput getEndscreenInput()
    {
        return this.input;
    }

    void Start()
    {
        init();
    }

    void OnGUI()
    {
        headingSize = (Screen.width + Screen.height) / 20;
        textSize = (Screen.width + Screen.height) / 30;
        imageSize = (Screen.width + Screen.height) / 25;

        text[0].fontSize = (int)headingSize;
        text[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[0].GetComponent<RectTransform>().anchoredPosition.x, -0.1f * Screen.height);

        for (int i = 1; i < text.Length; i++)
        {
            text[i].fontSize = (int)textSize;
            text[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.15f * i - 0.2f) * Screen.height);
        }
        GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 - GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().sizeDelta.x / 2, -0.55f * Screen.height);
        GetComponentsInChildren<Image>()[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 + GetComponentsInChildren<Image>()[2].GetComponent<RectTransform>().sizeDelta.x / 2, -0.55f * Screen.height);
        GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().sizeDelta = new Vector2(imageSize, imageSize);
        GetComponentsInChildren<Image>()[2].GetComponent<RectTransform>().sizeDelta = new Vector2(imageSize, imageSize);

    }

    private void upAndDown(InputAction.CallbackContext obj)
    {
        text[active].color = Color.white;
        active = (active == 3) ? 4 : 3;
        text[active].color = Color.yellow;
    }

    private void select(InputAction.CallbackContext obj)
    {
        if (active == 3)
        {
            //SceneManager.LoadScene("Level_1");
            GameObject.Find("GameControl").GetComponent<GameControlScript>().setInputRestart();
            GameObject.Find("HUD").SetActive(true);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            
        }
        else
        {
            Application.Quit();
        }
    }
}
