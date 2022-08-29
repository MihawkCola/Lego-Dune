using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {
    // Changelevel on activation
    private void OnEnable()
    {
        SceneManager.LoadScene("Level_1");
    }
}
