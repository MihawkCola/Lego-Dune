using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MenuControlScript : MonoBehaviour
{

    private MenuInput input;
    private Text[] text;
    private GameObject pauseMenu;
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
        text = GameObject.Find("PauseMenu").GetComponentsInChildren<Text>();
        text[1].color = Color.yellow;
        options = text.Length - 1;
        Debug.Log("ops: " + options);
        opMenus = new GameObject[options];
        for (int i = 1; i <= options; i++)
        {
            opMenus[i-1] = GameObject.Find("Option" + i + "Menu");
            opMenus[i-1].SetActive(false);
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

    }

    public void InputOff()
    {
        input.Pause.Up.started -= up;
        input.Pause.Down.started -= down;
        input.Pause.Select.started -= select;
        input.Option1.Red.started -= red;

    }


    private void red(InputAction.CallbackContext obj)
    {
        //opMenus[1].GetComponent<Text>().color = Color.red;
        GameObject.Find("Option1").GetComponent<Text>().color = Color.red;
        Debug.Log("RED");
    }

    private void up(InputAction.CallbackContext obj)
    {
        Debug.Log("UP");

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
        pauseMenu = GameObject.Find("PauseMenu");

        pauseMenu.SetActive(false);
        opMenus[active].SetActive(true);
        input.Pause.Disable();
        input.Option1.Enable();
    }
    public MenuInput getMenuInput() { 
        return this.input;
    }


}
