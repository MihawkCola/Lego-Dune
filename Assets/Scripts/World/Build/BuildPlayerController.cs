using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlayerController : MonoBehaviour
{
    public bool canBuild = false;

    private PlayerControl playerControl;
    
    private List<BuildController> buildControllers;

    private PlayerInput inputs;

    private Animator animator;

    private void Awake()
    {
        this.buildControllers = new List<BuildController>();
    }
    void Start()
    {
        this.playerControl = GetComponent<PlayerControl>();
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        animator = GetComponentInChildren<Animator>();
    }

    public void addBuild(BuildController buildController) { 
        this.buildControllers.Add(buildController);
        this.addInput();
    }
    public void removeBuild(BuildController buildController)
    {
        this.buildControllers.Remove(buildController);
        this.removeInput();

    }
    private void addInput() {
        inputs.Player.Build.started += buildGo;
        inputs.Player.Build.canceled += buildStop;
    }
    private void removeInput()
    {
        if (this.buildControllers.Count > 0) return;
        inputs.Player.Build.started -= buildGo;
        inputs.Player.Build.canceled -= buildStop;
        this.animator.SetBool("build", false);
        this.playerControl.movEnable = true;
    }
    private void buildStop(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!this.playerControl.getActive()) return;
        foreach (BuildController build in this.buildControllers)
        {
            build.buildStop();
        }
        this.animator.SetBool("build", false);
        this.playerControl.movEnable = true;
    }

    private void buildGo(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(!this.playerControl.getActive()) return;
        foreach (BuildController build in this.buildControllers) {
            build.buildGo();
        }
        this.animator.SetBool("build", true);
        this.playerControl.movEnable = false;
    }

    
}
