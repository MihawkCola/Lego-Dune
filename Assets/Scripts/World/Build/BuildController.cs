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

    private List<BuildPlayerController> controllerList;

    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        controllerList = new List<BuildPlayerController>();
    }

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

        for (int i = this.buildIndex; this.buildIndex < limit; this.buildIndex++) {
            Transform stone = this.stones.GetChild(this.buildIndex);

            StoneLerp lerpScript = stone.gameObject.AddComponent<StoneLerp>();
            lerpScript.goToTarget(this.build.GetChild(this.buildIndex), speed, this.buildIndex, this);
            Debug.Log(buildIndex);
        }
        checkFinish();
    }

    internal void checkLastStone(int indexStone)
    {
        if (indexStone != build.childCount - 1) return;
        Transform coins = this.transform.Find("CoinExplosion");
        if(coins != null)
            Destroy(coins.gameObject);
    }
    private void checkFinish()
    {
        if (this.buildIndex < build.childCount) return;
        isBuild = false;

        foreach (BuildPlayerController player in controllerList) {
            player.removeBuild(this);
        }
        controllerList.Clear();
        GetComponent<SphereCollider>().enabled = false;
    }

    public void canBuild() {
        this.GetComponent<Collider>().enabled = true;
    }

    public void buildGo()
    {
        delayTimer = Time.time;
        isBuild = true;
    }
    public void buildStop()
    {
        isBuild= false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        BuildPlayerController player = other.GetComponent<BuildPlayerController>();
        if (player != null)
        {
            player.addBuild(this);
            this.controllerList.Add(player);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        BuildPlayerController player = other.GetComponent<BuildPlayerController>();
        if (player != null)
        {
            player.removeBuild(this);
            this.controllerList.Remove(player);
        }   
    }
}
