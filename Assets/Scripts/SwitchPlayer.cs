 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private Camera mainCam;

    private PlayerInput inputs;
    private PlayerControl player1C;
    private PlayerControl player2C;
    private PlayerCamera cameraC;
    private bool isSwitch = false;

    private void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        this.player1C = player1.GetComponent<PlayerControl>();
        this.player2C = player2.GetComponent<PlayerControl>();
        this.cameraC = this.mainCam.GetComponent<PlayerCamera>();
        
        this.player1C.setCam(mainCam);

        this.player2C.setCam(mainCam);

        
        this.cameraC.setTarget(player1);
        this.InputOn();
        StartCoroutine(EnableInputFirstPlayer());
    }
    public void InputOn()
    {
        inputs.Player.SwitchPlayer.started += isPlayer;
    }

    public void InputOff()
    {
        inputs.Player.SwitchPlayer.started -= isPlayer;
    }
    private IEnumerator EnableInputFirstPlayer()
    {
        while(!player1C.IsInputsSet())
        {
            yield return new WaitForSeconds(0.1f);
        }

        player1C.InputOn();
    }

    private void isPlayer(InputAction.CallbackContext obj)
    {
        if(isSwitch = !isSwitch) 
        {
            this.cameraC.setTarget(player2);
            this.player1C.InputOff();
            this.player2C.InputOn();
        }
        else
        {
            this.cameraC.setTarget(player1);
            this.player2C.InputOff();
            this.player1C.InputOn();
        }

        
    }
}
