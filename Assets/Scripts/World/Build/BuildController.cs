using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildController : MonoBehaviour
{
    [SerializeField] private Transform build;
    [SerializeField] private Transform stones;

    private int buildIndex = 0;

    private PlayerInput inputs;

    private bool isBuild;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        building();
    }

    private void building()
    {
        if (!isBuild) return;
        Debug.Log("build");
        Transform stone = this.stones.GetChild(this.buildIndex);
        Destroy(stone.GetComponent<Rigidbody>());

        StoneLerp lerpScript = stone.gameObject.AddComponent<StoneLerp>();
        lerpScript.goToTarget(this.build.GetChild(this.buildIndex));
        this.buildIndex++;
        finish();
    }

    private void finish()
    {
        if (this.buildIndex < build.childCount) return;
        isBuild = false;
        inputs.Player.Build.started -= buildGo;
        inputs.Player.Build.canceled -= buildGo;
    }

    public void canBuild() {
        inputs.Player.Build.started += buildGo;
        inputs.Player.Build.canceled += buildGo;
    }

    private void buildGo(InputAction.CallbackContext obj)
    {
        isBuild = true;
    }
    private void buildStop(InputAction.CallbackContext obj)
    {
        isBuild= false;
    }

}
