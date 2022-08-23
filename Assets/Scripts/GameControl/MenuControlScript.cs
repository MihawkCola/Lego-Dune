using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MenuControlScript : MonoBehaviour
{

    private MenuInput input;
    private GameObject pauseMenu;
    private GameObject[] opMenus;
    private GameObject lautstaerkeMenu;
    private Text[] textPause;
    private int activePause;
    private int optionsPause;
    private Text[] textLautstaerke;
    private int activeLautstaerke;
    private int optionsLautstaerke;
    private Slider[] lautstaerkeSlider;

    private void Awake()
    {
        input = new MenuInput();
    }

    private void OnEnable()
    {
        input.Enable();
        initPause();
    }

    private void initPause()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        textPause = pauseMenu.GetComponentsInChildren<Text>();
        textPause[1].color = Color.yellow;
        optionsPause = textPause.Length - 1;
        opMenus = new GameObject[optionsPause];
        for (int i = 1; i <= optionsPause; i++)
        {
            opMenus[i - 1] = GameObject.Find("Option" + i + "Menu");
            opMenus[i - 1].SetActive(false);
        }
    }

    private void initLautstaerke()
    {
        lautstaerkeMenu = GameObject.Find("Option1Menu");
        textLautstaerke = lautstaerkeMenu.GetComponentsInChildren<Text>();
        textLautstaerke[1].color = Color.yellow;
        textLautstaerke[2].color = Color.white; //Nach fix prüfen, ob noch nötig
        optionsLautstaerke = textLautstaerke.Length - 1;
        lautstaerkeSlider = lautstaerkeMenu.GetComponentsInChildren<Slider>();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputOn();
        activePause = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputOn()
    {
        input.Pause.Up.started += upPause;
        input.Pause.Down.started += downPause;
        input.Pause.Select.started += select;
        input.Volume.Up.started += upLautstaerke;
        input.Volume.Down.started += downLautstaerke;
        input.Volume.Plus.started += plus;
        input.Volume.Minus.started += minus;
        input.Volume.Back.started += back;
    }

    public void InputOff()
    {
        input.Pause.Up.started -= upPause;
        input.Pause.Down.started -= downPause;
        input.Pause.Select.started -= select;
        input.Volume.Up.started -= upLautstaerke;
        input.Volume.Down.started -= downLautstaerke;
        input.Volume.Plus.started -= plus;
        input.Volume.Minus.started -= minus;
        input.Volume.Back.started -= back;
    }

    private void plus(InputAction.CallbackContext obj)
    {
        lautstaerkeSlider[activeLautstaerke].value += 0.2f;
    }

    private void minus(InputAction.CallbackContext obj)
    {
        lautstaerkeSlider[activeLautstaerke].value -= 0.2f;
    }

    private void back(InputAction.CallbackContext obj)
    {
        pauseMenu.SetActive(true);
        opMenus[activePause].SetActive(false);
        input.Volume.Disable();
        input.Pause.Enable();
    }

    private void upPause(InputAction.CallbackContext obj)
    {
        activePause = up(textPause, activePause, optionsPause);
    }
    private void upLautstaerke(InputAction.CallbackContext obj)
    {
        activeLautstaerke = up(textLautstaerke, activeLautstaerke, optionsLautstaerke);
    }

    private int up(Text[] text, int active, int options)
    {
        text[active + 1].color = Color.white;
        active = ((active - 1) >= 0) ? (active - 1) : (options - 1);
        text[active + 1].color = Color.yellow;
        return active;
    }

    private void downPause(InputAction.CallbackContext obj)
    {
        activePause = down(textPause, activePause, optionsPause);
    }
    private void downLautstaerke(InputAction.CallbackContext obj)
    {
        activeLautstaerke = down(textLautstaerke, activeLautstaerke, optionsLautstaerke);
    }

    private int down(Text[] text, int active, int options)
    {
        text[active + 1].color = Color.white;
        active = (active + 1) % options;
        text[active + 1].color = Color.yellow;
        return active;
    }

    private void select(InputAction.CallbackContext obj)
    {
        pauseMenu.SetActive(false);
        opMenus[activePause].SetActive(true);
        input.Pause.Disable();
        
        switch (activePause)
        {
            case 0:
                initLautstaerke();
                input.Volume.Enable();
                break;

            case 1:
                break;

            case 2:
                break;

            default:
                break;
        }
        
    }
    public MenuInput getMenuInput() { 
        return this.input;
    }


}
