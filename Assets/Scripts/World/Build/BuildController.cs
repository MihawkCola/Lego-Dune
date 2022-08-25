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

    public float delayBetween = 0.2f;
    private float delayTimer = 0.0f;

    public float speed = 2f;

    public int stoneParallel = 1;

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
        if (delayTimer > Time.time) return;
        this.delayTimer += delayBetween;

        int limit = this.buildIndex + stoneParallel;
        if (limit > build.childCount)
            limit = build.childCount;

        Debug.Log("build");
        for (int i = this.buildIndex; this.buildIndex < limit; this.buildIndex++) {
            Transform stone = this.stones.GetChild(this.buildIndex);

            StoneLerp lerpScript = stone.gameObject.AddComponent<StoneLerp>();
            lerpScript.goToTarget(this.build.GetChild(this.buildIndex), speed);
            Debug.Log(buildIndex);
        }
        checkFinish();
    }

    private void checkFinish()
    {
        if (this.buildIndex < build.childCount) return;
        isBuild = false;
    }

    public void canBuild() {
        this.GetComponent<Collider>().enabled = true;
    }

    private void buildGo(InputAction.CallbackContext obj)
    {
        delayTimer = Time.time;
        isBuild = true;
    }
    private void buildStop(InputAction.CallbackContext obj)
    {
        isBuild= false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        inputs.Player.Build.Enable();
        inputs.Player.Build.started += buildGo;
        inputs.Player.Build.canceled += buildStop;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;

        inputs.Player.Build.started -= buildGo;
        inputs.Player.Build.canceled -= buildStop;
        inputs.Player.Build.Disable();

    }

}
