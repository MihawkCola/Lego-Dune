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

    private void Awake()
    {
        this.slideWormScript = this.GetComponent<SlideWormScript>();
        Transform stages = this.transform.Find("Stages");

        this.stages = new Stage[stages.childCount];
        for (int i = 0; i < stages.childCount; i++)
        {
            this.stages[i] = stages.transform.GetChild(i).GetComponent<Stage>();
            this.stages[i].enabled = false;
        }
    }
    void Start()
    {  
        this.stages[0].enabled = true;
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
    }

    private void finish()
    {
        Debug.Log("Sandwalk ist beendet");
        //ToDo
    }
    public Color[] getColors() 
    {
        if(this.reandomColors == null) this.generateRandomColor();
        return this.reandomColors;
    }
    public Stage getActiveStage() {
        return this.stages[stageIndex];
    }

}
