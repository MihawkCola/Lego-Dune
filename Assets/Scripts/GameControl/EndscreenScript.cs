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

    private void Awake()
    {
        input = new StartOrQuitInput();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
       
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
