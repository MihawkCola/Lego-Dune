 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject otherPlayer;
    private PlayerInput inputs;

    private void Awake()
    {
        inputs = new PlayerInput();
        otherPlayer.GetComponent<PlayerControl>().enabled = false;
        otherPlayer.GetComponentInChildren<Camera>().enabled = false;
        GetComponent<PlayerControl>().enabled = true;
        GetComponentInChildren<Camera>().enabled = true;

    }
    private void OnEnable()
    {
        inputs.Player.SwitchPlayer.started += isPlayer;
        inputs.Player.Enable();
    }


    private void OnDisable()
    {
        inputs.Player.SwitchPlayer.started -= isPlayer;
        inputs.Player.Disable();
    }
    private void isPlayer(InputAction.CallbackContext obj)
    {
        if(otherPlayer.GetComponent<PlayerControl>().enabled) 
        {
            otherPlayer.GetComponent<PlayerControl>().enabled = false;
            GetComponent<PlayerControl>().enabled = true;
            otherPlayer.GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<Camera>().enabled = true;
        }
        else
        {
            GetComponent<PlayerControl>().enabled = false;
            otherPlayer.GetComponent<PlayerControl>().enabled = true;
            GetComponentInChildren<Camera>().enabled = false;
            otherPlayer.GetComponentInChildren<Camera>().enabled = true;
        }

        
    }
}
