using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class MenuControlScript : MonoBehaviour
{

    private MenuInput input;
    private Text text;

    private void Awake()
    {
        input = new MenuInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputOn()
    {
        input.Pause.Test.started += test;
    }

    public void InputOff()
    {
        input.Pause.Test.started -= test;
    }

    private void test(InputAction.CallbackContext obj)
    {
        if (text.color != Color.red)
        {
            text.color = Color.red;
        }

        else
        {
            text.color = Color.white;
        }
    }


}
