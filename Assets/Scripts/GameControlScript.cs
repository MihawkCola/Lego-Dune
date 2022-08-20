using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameControlScript : MonoBehaviour
{
    private GameInput input;
    private bool isPaused;
    private GameObject pauseMenu;

    private void Awake()
    {
        input = new GameInput();
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
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        isPaused = false;
        GameObject.Find("Menu").GetComponent<MenuControlScript>().enabled = false;
        //GameObject.Find("PlayerInput").GetComponent<PlayerControl>().enabled = true;
        //input.GameControl.Pause.performed += _ => pauseGame2();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InputOn()
    {
        input.GameControl.Pause.started += pauseGame;
    }

    public void InputOff()
    {
        input.GameControl.Pause.started -= pauseGame;
    }

    private void pauseGame(InputAction.CallbackContext obj)
    {
        Debug.Log("ESC");
        /*if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            GameObject.Find("PlayerInput").GetComponent<PlayerInput>().Disable();
            GameObject.Find("Menu").GetComponent<PlayerInput>().Enable();
            Time.timeScale = 0;
        }

        else
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            GameObject.Find("Menu").GetComponent<PlayerInput>().Disable();
            GameObject.Find("PlayerInput").GetComponent<PlayerInput>().Enable();
            Time.timeScale = 1;
        }*/
    }

}
