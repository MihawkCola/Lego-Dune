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

    private HealthController healthController;

    private GameObject activePlayer;

    private EnemyController enemyController;

    private void Awake()
    {

        this.enemyController = GameObject.Find("EnemyManager").GetComponent<EnemyController>();

        this.healthController = this.GetComponent<HealthController>();

        this.player1C = player1.GetComponent<PlayerControl>();
        this.player2C = player2.GetComponent<PlayerControl>();
        this.cameraC = this.mainCam.GetComponent<PlayerCamera>();

        this.activePlayer = this.player1;

    }

    private void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();

        this.player1C.setCam(mainCam);
        this.player2C.setCam(mainCam);

        this.cameraC.changeCameraTarget(player1);
        this.InputOn();
        StartCoroutine(EnableInputFirstPlayer());

        //this.GetComponentInParent<SandWalkScript>().setPlayer(player1);
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
        if (this.healthController.isOneDeath()) return;

        this.switchPlayer();
    }

    public void switchPlayer() { 
        if(isSwitch = !isSwitch) 
        {
            this.cameraC.changeCameraTarget(player2);
            this.player1C.InputOff();
            this.player2C.InputOn();

            this.activePlayer = this.player2;
        }
        else
        {
            this.cameraC.changeCameraTarget(player1);
            this.player2C.InputOff();
            this.player1C.InputOn();

            this.activePlayer = this.player1;
        }
        enemyController.changeAllTarget(this.activePlayer.transform);
    }

    public void disableCamera(Camera other) 
    {
        this.mainCam.gameObject.SetActive(false);
        inputs.Disable();
        other.gameObject.SetActive(true);
    }
    public void activateCamera(Camera other) 
    {
        other.gameObject.SetActive(false);
        inputs.Enable();
        this.mainCam.gameObject.SetActive(true);
    }
    public void shakePlayerCamera(float duration, float magnitude)
    {
        this.cameraC.startSake(duration, magnitude);
    }

    public void checkDeathPlayerActive() {
        if (!this.activePlayer.GetComponent<HealthScript>().isDeath()) return;

        if (this.healthController.allDeath()) return;

        Debug.Log("switch");
        this.switchPlayer();
    }

    public Transform getActivePlayer()
    {
        return activePlayer.transform;
    }
}
