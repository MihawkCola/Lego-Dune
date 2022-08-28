using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EndscreenScript : MonoBehaviour
{
    private StartOrQuitInput input;

    private GameObject endscreen;
    private Text[] text;
    private int active;
    private int headingSize;
    private int textSize;

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

    private void init()
    {
        endscreen = GameObject.Find("Endscreen");
        text = endscreen.GetComponentsInChildren<Text>();
        //endscreen.GetComponentsInChildren<Text>()[2].text = 
        endscreen.GetComponentsInChildren<Text>()[2].text = "gufuzddözdzu"; //GameObject.Find("HUD").GetComponent<CoinsScript>().getCoinAmount().ToString();
        GetComponentsInChildren<Image>()[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 - GetComponentsInChildren<Image>()[0].GetComponent<RectTransform>().sizeDelta.x / 2, -223);
        GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 + GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().sizeDelta.x / 2, -223);

        active = 3;
        text[active].color = Color.yellow;
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        headingSize = (Screen.width + Screen.height) / 20;
        textSize = (Screen.width + Screen.height) / 30;

        text[0].fontSize = (int)headingSize;
        text[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[0].GetComponent<RectTransform>().anchoredPosition.x, -0.1f * Screen.height);

        for (int i = 1; i < text.Length; i++)
        {
            text[i].fontSize = (int)textSize;
            text[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.15f * i - 0.2f) * Screen.height);
        }
        GetComponentsInChildren<Image>()[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(-endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 - GetComponentsInChildren<Image>()[0].GetComponent<RectTransform>().sizeDelta.x / 2, text[2].GetComponent<RectTransform>().sizeDelta.y);
        GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(endscreen.GetComponentsInChildren<Text>()[2].GetComponent<RectTransform>().sizeDelta.x / 2 + GetComponentsInChildren<Image>()[1].GetComponent<RectTransform>().sizeDelta.x / 2, -223);

    }

    public void InputOn()
    {
        input.StartOrQuit.Up.started += upAndDown;
        input.StartOrQuit.Down.started += upAndDown;
        input.StartOrQuit.Select.started += select;
    }

    private void upAndDown(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void select(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
}
