using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step: MonoBehaviour
{
    private ButtonScript[] buttonS;
    private Color[] colorButton;

    private int[] sequence;
    private int indexSequence;

    [SerializeField] private int sequenzNumber;
    [SerializeField] private Color[] colorsPoll;
    private void Awake()
    { 

    }
    void Start()
    {
        this.indexSequence = 0;
        this.buttonS = new ButtonScript[this.transform.childCount];
        for (int i = 0; i < this.buttonS.Length; i++)
        {
            this.buttonS[i] = this.transform.GetChild(i).GetComponentInChildren<ButtonScript>();
        }
        this.initColor();
    }

    private void initColor() {

        Debug.Log(Random.Range(0, 2));
        Debug.Log(Random.Range(0, 2));
        Debug.Log(Random.Range(0, 2));
        Debug.Log(Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
