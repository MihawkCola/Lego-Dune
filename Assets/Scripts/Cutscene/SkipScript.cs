using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SkipScript : MonoBehaviour
{
    private SkipScene input;

    private void Start()
    {
        input = new SkipScene();
        input.Enable();
        input.skip.skip.started += loadLevel;
    }

    private void loadLevel(InputAction.CallbackContext obj)
    {
        input.skip.skip.started -= loadLevel;
        SceneManager.LoadScene("Level_1");
    }
}
