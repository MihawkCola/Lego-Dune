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
    private Text[] textPause;
    private int activePause;
    private int optionsPause;

    private GameObject lautstaerkeMenu;
    private Text[] textLautstaerke;
    private int activeLautstaerke;
    private int optionsLautstaerke;
    private Slider[] lautstaerkeSlider;
    private AudioSource[] audioSources;

    private GameObject aufloesungMenu;
    private Text[] textAufloesung;
    private int activeAufloesung;
    private int optionsAufloesung;


    private void Awake()
    {
        input = new MenuInput();
        InputOnPause();
        input.Volume.Disable();
        input.Resolution.Disable();

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
        lautstaerkeSlider[0].value = GameObject.Find("Level").GetComponent<AudioSource>().volume;
        lautstaerkeSlider[1].value = 1;
    }

    private void initAufloesung()
    {
        aufloesungMenu = GameObject.Find("Option2Menu");
        textAufloesung = aufloesungMenu.GetComponentsInChildren<Text>();
        textAufloesung[1].color = Color.yellow;
        textAufloesung[2].color = Color.white; //Nach fix prüfen, ob noch nötig
        textAufloesung[3].color = Color.white; //Nach fix prüfen, ob noch nötig
        optionsAufloesung = textAufloesung.Length - 1;
        
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        activePause = 0;
        audioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InputOn()
    {
        input.Pause.Up.started += upPause;
        input.Pause.Down.started += downPause;
        input.Pause.Select.started += selectMenu;
    
        input.Volume.Up.started += upLautstaerke;
        input.Volume.Down.started += downLautstaerke;
        input.Volume.Plus.started += plus;
        input.Volume.Minus.started += minus;
        input.Volume.Back.started += back;
    
        input.Resolution.Up.started += upAufloesung;
        input.Resolution.Down.started += downAufloesung;
        input.Resolution.Back.started += back;
        input.Resolution.Select.started += selectResolution;
    }
    public void InputOnPause()
    {
        input.Pause.Up.started += upPause;
        input.Pause.Down.started += downPause;
        input.Pause.Select.started += selectMenu;
    }

    public void InputOnVolume()
    {
        input.Volume.Up.started += upLautstaerke;
        input.Volume.Down.started += downLautstaerke;
        input.Volume.Plus.started += plus;
        input.Volume.Minus.started += minus;
        input.Volume.Back.started += back;
    }
    public void InputOnResolution()
    {
        input.Resolution.Up.started += upAufloesung;
        input.Resolution.Down.started += downAufloesung;
        input.Resolution.Back.started += back;
        input.Resolution.Select.started += selectResolution;
    }

    public void InputOff()
    {
        input.Pause.Up.started -= upPause;
        input.Pause.Down.started -= downPause;
        input.Pause.Select.started -= selectMenu;

        input.Volume.Up.started -= upLautstaerke;
        input.Volume.Down.started -= downLautstaerke;
        input.Volume.Plus.started -= plus;
        input.Volume.Minus.started -= minus;
        input.Volume.Back.started -= back;

        input.Resolution.Up.started -= upAufloesung;
        input.Resolution.Down.started -= downAufloesung;
        input.Resolution.Back.started -= back;
        input.Resolution.Select.started -= selectResolution;
    }

    private void plus(InputAction.CallbackContext obj)
    {
        lautstaerkeSlider[activeLautstaerke].value += 0.1f;
        switch (activeLautstaerke)
        {
            case 0:
                GameObject.Find("Level").GetComponent<AudioSource>().volume += 0.1f;
                break;
            case 1:
                float backgroundMusicVol = GameObject.Find("Level").GetComponent<AudioSource>().volume;
                foreach (AudioSource audio in audioSources)
                {
                    audio.volume += 0.1f;
                }
                GameObject.Find("Level").GetComponent<AudioSource>().volume = backgroundMusicVol;

                audioSources[1].Play();
                break;
            default:
                break;
        }
    }

    private void minus(InputAction.CallbackContext obj)
    {
        lautstaerkeSlider[activeLautstaerke].value -= 0.1f;
        switch (activeLautstaerke)
        {
            case 0:
                GameObject.Find("Level").GetComponent<AudioSource>().volume -= 0.1f;
                break;
            case 1:
                float backgroundMusicVol = GameObject.Find("Level").GetComponent<AudioSource>().volume;
                foreach (AudioSource audio in audioSources)
                {
                    audio.volume -= 0.1f;
                }
                GameObject.Find("Level").GetComponent<AudioSource>().volume = backgroundMusicVol;
                audioSources[1].Play();

                break;
            default:
                break;
        }
    }

    private void back(InputAction.CallbackContext obj)
    {
        back();
    }

    private void back()
    {
        pauseMenu.SetActive(true);
        opMenus[activePause].SetActive(false);
        input.Volume.Disable();
        input.Resolution.Disable();
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
    private void upAufloesung(InputAction.CallbackContext obj)
    {
        activeAufloesung = up(textAufloesung, activeAufloesung, optionsAufloesung);
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
    private void downAufloesung(InputAction.CallbackContext obj)
    {
        activeAufloesung = down(textAufloesung, activeAufloesung, optionsAufloesung);
    }

    private int down(Text[] text, int active, int options)
    {
        text[active + 1].color = Color.white;
        active = (active + 1) % options;
        text[active + 1].color = Color.yellow;
        return active;
    }

    private void selectResolution(InputAction.CallbackContext obj)
    {
        switch (activeAufloesung)
        {
            case 0:
                Screen.SetResolution(720, 576, false);
                break;

            case 1:
                Screen.SetResolution(1280, 720, false);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, false);
                break;

            default:
                break;
        }
        Debug.Log("Res: " + Screen.currentResolution);
        back();
    }
    private void selectMenu(InputAction.CallbackContext obj)
    {
        pauseMenu.SetActive(false);
        opMenus[activePause].SetActive(true);
        input.Pause.Disable();
        
        switch (activePause)
        {
            case 0:
                input.Resolution.Disable();
                input.Volume.Enable();

                initLautstaerke();
                //InputOnVolume();
                break;

            case 1:
                input.Volume.Disable();
                input.Resolution.Enable();

                initAufloesung();
                //InputOnResolution();
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
