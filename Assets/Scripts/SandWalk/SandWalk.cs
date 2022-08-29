using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWalk : MonoBehaviour
{
    public float disableEnableDelay;

    public Color[] colorsPoll;
    private Color[] reandomColors;


    private Stage[] stages;
    private SlideWormScript slideWormScript;
    private int stageIndex;
    private AnimationController a_controller;

    private void Awake()
    {
        this.a_controller = this.transform.GetComponentInChildren<AnimationController>();
        this.slideWormScript = this.GetComponent<SlideWormScript>();
        Transform stages = this.transform.Find("Stages");

        this.stages = new Stage[stages.childCount];
        for (int i = 0; i < stages.childCount; i++)
        {
            this.stages[i] = stages.transform.GetChild(i).GetComponent<Stage>();
            this.stages[i].enabled = false;
        }

        this.enabled = true;
        slideWormScript.enabled = false;
    }
    public void StartGame()
    {
        this.stages[0].enabled = true;
        this.StartAnimation();
    }

    public void StartAnimation() 
    {
        this.a_controller.StartAnimation();
    }
    public void StartSlide() 
    {
        slideWormScript.enabled = true;
    }

    public void StopSlide()
    {
        slideWormScript.enabled = false;
    }

    private void generateRandomColor()
    {
        List<Color> colors = new List<Color>(this.colorsPoll);
        this.reandomColors = new Color[this.colorsPoll.Length];

        for (int i = 0; i < this.reandomColors.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, colors.Count);

            this.reandomColors[i] = colors[randomIndex];
            colors.RemoveAt(randomIndex);
        }
    }

    public void nextStage() {
        stageIndex++;
        this.stages[stageIndex-1].enabled = false;
        this.slideWormScript.resetValue();
        if (this.stageIndex >= this.stages.Length) 
        {
            this.finish();
            return;
        }
        this.stages[stageIndex].enabled = true;
        this.StartAnimation();
    }

    private void finish()
    {
        Debug.Log("Sandwalk ist beendet");
        Invoke("startEndScreen", 1.5f);
    }
    private void startEndScreen() {
        GameObject.Find("GameControl").GetComponent<GameControlScript>().showEndscreen();
    }
    public Color[] getColors() 
    {
        if(this.reandomColors == null) this.generateRandomColor();
        return this.reandomColors;
    }
    public int[] getActiveStageSequence() {
        return this.stages[stageIndex].getSequence();
    }

}
