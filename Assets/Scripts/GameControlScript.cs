using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameControlScript : MonoBehaviour
{
    private GameInput input;
    private bool isPaused;
    private GameObject pauseMenu;

    private PlayerInput playerInput;
    private MenuInput menuInput;
    private AudioSource[] audios;

    private void Awake()
    {
        input = new GameInput();
        playerInput = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();

        //input.GameControl.Pause.started += pauseGame;
        InputOn();
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
        playerInput = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        menuInput = GameObject.Find("Menu").GetComponent<MenuControlScript>().getMenuInput();

        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        isPaused = false;
    }

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
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            playerInput.Disable();
            menuInput.Enable();
            Time.timeScale = 0;

            audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios) { 
                audio.Pause();
            }
        }

        else
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            menuInput.Disable();
            playerInput.Enable();
            Time.timeScale = 1;

            //AudioSource[] audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.UnPause();
            }
        }
    }

}
