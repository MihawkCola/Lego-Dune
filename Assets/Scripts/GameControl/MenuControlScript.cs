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

    private GameObject spielmodiMenu;
    private Text[] textModi;
    private int activeModi;
    private int optionsModi;


    private void Awake()
    {
        input = new MenuInput();
        //InputOnPause();
    }

    private void OnEnable()
    {
        input.Enable();
        initPause();
        InputOnPause();
    }

    private void initPause()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        textPause = pauseMenu.GetComponentsInChildren<Text>();
        textPause[activePause + 1].color = Color.yellow;
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
        textLautstaerke[activeLautstaerke + 1].color = Color.yellow;
        optionsLautstaerke = textLautstaerke.Length - 1;
        lautstaerkeSlider = lautstaerkeMenu.GetComponentsInChildren<Slider>();
        lautstaerkeSlider[0].value = GameObject.Find("Level").GetComponent<AudioSource>().volume;
        lautstaerkeSlider[1].value = GetComponent<AudioSource>().volume;
    }

    private void initAufloesung()
    {
        aufloesungMenu = GameObject.Find("Option2Menu");
        textAufloesung = aufloesungMenu.GetComponentsInChildren<Text>();
        textAufloesung[activeAufloesung + 1].color = Color.yellow;
        optionsAufloesung = textAufloesung.Length - 1;
        
    }
    private void initSpielmodi()
    {
        spielmodiMenu = GameObject.Find("Option3Menu");
        textModi = spielmodiMenu.GetComponentsInChildren<Text>();
        textModi[activeModi + 1].color = Color.yellow;
        optionsModi = textModi.Length - 1;

    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void InputOnModes()
    {
        input.Modes.Up.started += upSpielmodi;
        input.Modes.Down.started += downSpielmodi;
        input.Modes.Back.started += back;
        //input.Modes.Select.started += selectSpielmodi;
    }
    public void InputOffPause()
    {
        input.Pause.Up.started -= upPause;
        input.Pause.Down.started -= downPause;
        input.Pause.Select.started -= selectMenu;
    }
    public void InputOffVolume()
    {
        input.Volume.Up.started -= upLautstaerke;
        input.Volume.Down.started -= downLautstaerke;
        input.Volume.Plus.started -= plus;
        input.Volume.Minus.started -= minus;
        input.Volume.Back.started -= back;
    }
    public void InputOffResolution()
    {
        input.Resolution.Up.started -= upAufloesung;
        input.Resolution.Down.started -= downAufloesung;
        input.Resolution.Back.started -= back;
        input.Resolution.Select.started -= selectResolution;
    }
    public void InputOffModes()
    {
        input.Modes.Up.started -= upSpielmodi;
        input.Modes.Down.started -= downSpielmodi;
        input.Modes.Back.started -= back;
        //input.Modes.Select.started -= selectSpielmodi;
    }

    public void escape()
    {
        foreach (GameObject menu in opMenus)
        {
            menu.SetActive(false);
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
        InputOffVolume();
        InputOffResolution();
        InputOffModes();
        InputOnPause();
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
    private void upSpielmodi(InputAction.CallbackContext obj)
    {
        activeModi = up(textModi, activeModi, optionsModi);
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
    private void downSpielmodi(InputAction.CallbackContext obj)
    {
        activeModi = down(textModi, activeModi, optionsModi);
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
        Debug.Log("Res1: " + Screen.width + " x " + Screen.height);
        switch (activeAufloesung)
        {
            case 0:
                Screen.SetResolution(720, 576, Screen.fullScreenMode);
                break;

            case 1:
                Screen.SetResolution(1280, 720, Screen.fullScreenMode);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, Screen.fullScreenMode);
                break;

            default:
                break;
        }
        Debug.Log("Res2: " + Screen.width + " x "+ Screen.height);
        back();
    }
    private void selectMenu(InputAction.CallbackContext obj)
    {
        InputOffPause();
        pauseMenu.SetActive(false);
        opMenus[activePause].SetActive(true);

        switch (activePause)
        {
            case 0:
                initLautstaerke();
                InputOnVolume();
                break;

            case 1:
                initAufloesung();
                StartCoroutine(WaitForRealSeconds (0.1f));
                break;

            case 2:
                initSpielmodi();
                InputOnModes();
                break;

            default:
                break;
        }
        
    }
    //Quelle: https://forum.unity.com/threads/waitforseconds-while-time-scale-0.272786/
    IEnumerator WaitForRealSeconds(float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < seconds)
        {
            yield return null;
        }
        InputOnResolution();
    }

    public MenuInput getMenuInput() { 
        return this.input;
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
                GetComponent<AudioSource>().Play();
                //audioSources[1].Play();

                break;
            default:
                break;
        }
    }

}
