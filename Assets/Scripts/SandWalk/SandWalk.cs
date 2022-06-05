using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWalk : MonoBehaviour
{
    public float disableEnableDelay;

    public Color[] colorsPoll;


    private Stage[] stages;
    private SlideWormScript slideWormScript;
    private int stageIndex;
    void Start()
    {
        this.slideWormScript = this.GetComponent<SlideWormScript>();
        Transform stages = this.transform.Find("Stages");

        this.stages = new Stage[stages.childCount];
        for (int i = 0; i < stages.childCount; i++)
        {
            this.stages[i] = stages.transform.GetChild(i).GetComponent<Stage>();
            this.stages[i].enabled = false;
        }
        this.stages[0].enabled = true;
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
    }

    private void finish()
    {
        Debug.Log("Sandwalk ist beendet");
        //ToDo
    }

}
