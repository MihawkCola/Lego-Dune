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
    private Text[] text;
    private GameObject[] opMenus;
    private int active;
    private int options;

    private void Awake()
    {
        input = new MenuInput();
    }

    private void OnEnable()
    {
        input.Enable();
        init();
    }

    public void init()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        text = pauseMenu.GetComponentsInChildren<Text>();
        text[1].color = Color.yellow;
        options = text.Length - 1;
        opMenus = new GameObject[options];
        for (int i = 1; i <= options; i++)
        {
            opMenus[i - 1] = GameObject.Find("Option" + i + "Menu");
            opMenus[i - 1].SetActive(false);
        }
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputOn();
        active = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputOn()
    {
        input.Pause.Up.started += up;
        input.Pause.Down.started += down;
        input.Pause.Select.started += select;
        input.Option1.Red.started += red;
        input.Option1.Back.started += back;
    }

    public void InputOff()
    {
        input.Pause.Up.started -= up;
        input.Pause.Down.started -= down;
        input.Pause.Select.started -= select;
        input.Option1.Red.started -= red;
        input.Option1.Back.started -= back;
    }

    private void back(InputAction.CallbackContext obj)
    {
        pauseMenu.SetActive(true);
        opMenus[active].SetActive(false);
        input.Option1.Disable();
        input.Pause.Enable();
    }

    private void red(InputAction.CallbackContext obj)
    {
        GameObject.Find("Option1").GetComponent<Text>().color = Color.red;
    }

    private void up(InputAction.CallbackContext obj)
    {
        text[active + 1].color = Color.white;
        active = ((active - 1) >= 0) ? (active - 1) : (options - 1);
        text[active + 1].color = Color.yellow;
    }

    private void down(InputAction.CallbackContext obj)
    {
        text[active + 1].color = Color.white;
        active = (active + 1) % options;
        text[active + 1].color = Color.yellow;
    }                                                                     
    private void select(InputAction.CallbackContext obj)
    {
        pauseMenu.SetActive(false);
        opMenus[active].SetActive(true);
        input.Pause.Disable();
        switch (active)
        {
            case 1:
                input.Option1.Enable();
                break;

            case 2:
                break;

            case 3:
                break;

            default:
                break;
        }
        
    }
    public MenuInput getMenuInput() { 
        return this.input;
    }


}
