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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
