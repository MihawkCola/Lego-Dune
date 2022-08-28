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

    private float headingSize;
    private float textSize;

    private void Awake()
    {
        input = new MenuInput();
    }

    private void OnEnable()
    {
        input.Enable();
        initPause();
        InputOnPause();
    }

    public MenuInput getMenuInput()
    {
        return this.input;
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
        lautstaerkeSlider[1].value = GetComponents<AudioSource>()[1].volume;
        if (activeLautstaerke == 0)
        {
            GetComponents<AudioSource>()[0].Play();
        }
        else
        {
            GetComponents<AudioSource>()[1].Play();
        }
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

    void OnGUI()
    {
        if (pauseMenu.activeSelf)
        {
            setFontSizes(textPause);
        }
        else if (opMenus[0].activeSelf)
        {
            setFontSizesAndSlider(textLautstaerke, lautstaerkeSlider);
        }
        else if (opMenus[1].activeSelf)
        {
            setFontSizes(textAufloesung);
        }
        else if (opMenus[2].activeSelf)
        {
            setFontSizes(textModi);
        }
    }

    private void setFontSizes(Text[] text)
    {
        headingSize = (Screen.width + Screen.height) / 20;
        textSize = (Screen.width + Screen.height) / 30;

        text[0].fontSize = (int)headingSize;
        text[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[0].GetComponent<RectTransform>().anchoredPosition.x, -0.2f * Screen.height);

        for (int i = 1; i < text.Length; i++)
        {
            text[i].fontSize = (int) textSize;
            text[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.15f * i - 0.3f) * Screen.height);
        }
    }
    private void setFontSizesAndSlider(Text[] text, Slider[] slider)
    {
        headingSize = (Screen.width + Screen.height) / 20;
        textSize = (Screen.width + Screen.height) / 30;

        text[0].fontSize = (int)headingSize;
        text[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[0].GetComponent<RectTransform>().anchoredPosition.x, -0.2f * Screen.height);

        for (int i = 1; i < text.Length; i++)
        {
            text[i].fontSize = (int)textSize;
            text[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(text[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.25f * i - 0.2f) * Screen.height);
        }
        for (int i = 0; i < slider.Length; i++)
        {
            slider[i].GetComponent<RectTransform>().sizeDelta = new Vector2(0.5f * Screen.width, 20);
            slider[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(slider[i].GetComponent<RectTransform>().anchoredPosition.x, (-0.25f * i - 0.1f) * Screen.height);
        }
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
        input.Modes.Select.started += selectSpielmodi;
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
        input.Modes.Select.started -= selectSpielmodi;
    }

    private void back(InputAction.CallbackContext obj)
    {
        back();
    }

    public void back()
    {
        if(activePause == 0)
        {
            GetComponents<AudioSource>()[0].Pause();
            GetComponents<AudioSource>()[2].Play();
        }
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
        if (activeLautstaerke == 0)
        {
            GetComponents<AudioSource>()[0].Play();
        }
        else
        {
            GetComponents<AudioSource>()[0].Pause(); 
            GetComponents<AudioSource>()[1].Play();
        }
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
        if(activeLautstaerke == 0)
        {
            GetComponents<AudioSource>()[0].Play();
        }
        else
        {
            GetComponents<AudioSource>()[0].Pause();
            GetComponents<AudioSource>()[1].Play();
        }
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
        back();
    }
    private void selectSpielmodi(InputAction.CallbackContext obj) //TODO
    {
        switch (activeModi)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            default:
                break;
        }
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
                GetComponents<AudioSource>()[2].Pause();
                break;

            case 1:
                initAufloesung();
                StartCoroutine(WaitForRealSeconds(0.1f, true));
                break;

            case 2:
                initSpielmodi();
                StartCoroutine(WaitForRealSeconds(0.1f, false));
                break;

            default:
                break;
        }
        
    }
    //Quelle: https://forum.unity.com/threads/waitforseconds-while-time-scale-0.272786/
    IEnumerator WaitForRealSeconds(float seconds, bool resolution)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < seconds)
        {
            yield return null;
        }
        if (resolution) 
        {
            InputOnResolution();
        }
        else
        {
            InputOnModes();
        }
    }

    private void plus(InputAction.CallbackContext obj)
    {
        if(lautstaerkeSlider[activeLautstaerke].value < 1)
        {
            lautstaerkeSlider[activeLautstaerke].value += 0.1f;
            switch (activeLautstaerke)
            {
                case 0:
                    GameObject.Find("Level").GetComponent<AudioSource>().volume += 0.1f;
                    GetComponents<AudioSource>()[0].volume += 0.1f;
                    GetComponents<AudioSource>()[2].volume += 0.1f;
                    break;
                case 1:
                    float backgroundMusicVol = GameObject.Find("Level").GetComponent<AudioSource>().volume;
                    foreach (AudioSource audio in audioSources)
                    {
                        audio.volume += 0.1f;
                    }
                    GameObject.Find("Level").GetComponent<AudioSource>().volume = backgroundMusicVol;
                    GetComponents<AudioSource>()[0].volume = backgroundMusicVol;
                    GetComponents<AudioSource>()[2].volume = backgroundMusicVol;
                    GetComponents<AudioSource>()[1].Play();
                    break;
                default:
                    break;
            }
        }
    }

    private void minus(InputAction.CallbackContext obj)
    {
        if (lautstaerkeSlider[activeLautstaerke].value > 0)
        {
            lautstaerkeSlider[activeLautstaerke].value -= 0.1f;
            switch (activeLautstaerke)
            {
                case 0:
                    GameObject.Find("Level").GetComponent<AudioSource>().volume -= 0.1f;
                    GetComponents<AudioSource>()[0].volume -= 0.1f;
                    GetComponents<AudioSource>()[2].volume -= 0.1f;
                    break;
                case 1:
                    float backgroundMusicVol = GameObject.Find("Level").GetComponent<AudioSource>().volume;
                    foreach (AudioSource audio in audioSources)
                    {
                        audio.volume -= 0.1f;
                    }
                    GameObject.Find("Level").GetComponent<AudioSource>().volume = backgroundMusicVol;
                    GetComponents<AudioSource>()[0].volume = backgroundMusicVol; 
                    GetComponents<AudioSource>()[2].volume = backgroundMusicVol;
                    GetComponents<AudioSource>()[1].Play();
                    break;
                default:
                    break;
            }
        }
    }

}
