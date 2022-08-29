using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameControlScript : MonoBehaviour
{
    private GameInput input;
    private bool isPaused;

    private PlayerInput playerInput;
    private MenuInput menuInput;
    private StartOrQuitInput endscreenInput;
    private GameObject pauseMenu;
    private AudioSource[] audios;

    private GameObject endscreen;

    private void Awake()
    {
        input = new GameInput();
        input.GameControl.Pause.started += escape;
    }

    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    void Start()
    {
        playerInput = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        menuInput = GameObject.Find("Menu").GetComponent<MenuControlScript>().getMenuInput();
        endscreenInput = GameObject.Find("Endscreen").GetComponent<EndscreenScript>().getEndscreenInput();
        endscreen = GameObject.Find("Endscreen");
        endscreen.SetActive(false);
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
        menuInput.Disable();
        endscreenInput.Disable();
        isPaused = false;
    }

    private void escape(InputAction.CallbackContext obj)
    {
        un_pauseGame();
    }

    public void un_pauseGame()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            playerInput.Disable();
            menuInput.Enable();
            Time.timeScale = 0;

            audios = FindObjectsOfType<AudioSource>();

            foreach (AudioSource audio in audios)
            {
                audio.Pause();
            }
            GameObject.Find("Menu").GetComponents<AudioSource>()[2].Play();
        }

        else
        {
            if (!pauseMenu.activeSelf)
            {
                GameObject.Find("Menu").GetComponent<MenuControlScript>().back();
            }
            pauseMenu.SetActive(false);
            isPaused = false;
            menuInput.Disable();
            playerInput.Enable();
            Time.timeScale = 1;
            foreach (AudioSource audio in audios)
            {
                audio.UnPause();
            }
            GameObject.Find("Menu").GetComponents<AudioSource>()[2].Pause();
        }
    }

    public void showEndscreen()
    {
        Time.timeScale = 0;
        GameObject.Find("HUD").SetActive(false);
        endscreen.SetActive(true);
        playerInput.Disable();
        endscreenInput.Enable();
    }
    public void setInputRestart()
    {
        endscreenInput.Disable();
        menuInput.Disable();
        playerInput.Enable();
    }

}
