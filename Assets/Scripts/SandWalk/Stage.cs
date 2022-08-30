using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    private int buttonsCount;
    private ButtonScript[] buttonS;
    private Transform[] buttonGameobject;
    //private Color[] colorButton;

    private List<int> sequence;
    private int indexSequence;
    [SerializeField] private int startSequenzNumber;
    [SerializeField] private int sequenceRepetition;
    private bool isFinish;

    private SandWalk sandWalk;
    private SlideWormScript slideWormScript;

    public int step = 1;
    private void Awake()
    {
        this.indexSequence = 0;
        this.buttonsCount = this.transform.childCount;
        this.sequence = new List<int>();
        this.sandWalk = this.GetComponentInParent<SandWalk>();
        this.slideWormScript = this.GetComponentInParent<SlideWormScript>();
        if (this.buttonsCount > this.sandWalk.colorsPoll.Length)
            return;

        this.buttonS = new ButtonScript[buttonsCount];
        this.buttonGameobject = new Transform[buttonsCount];

        for (int i = 0; i < this.buttonS.Length; i++)
        {
            this.buttonS[i] = this.transform.GetChild(i).GetComponentInChildren<ButtonScript>();
            this.buttonS[i].setNumber(i);
            this.buttonGameobject[i] = this.transform.GetChild(i);
        }
        this.initColors();
        this.initSequence(this.startSequenzNumber);
        this.disableButtons();
    }
    void Start()
    {
        this.isFinish = false;
    }
    private void OnDisable()
    {
        this.Invoke("disableButtons", this.sandWalk.disableEnableDelay);
    }
    private void OnEnable()
    {
        this.Invoke("enableButtons", this.sandWalk.disableEnableDelay);
    }
    private void Reset()
    {
        this.indexSequence = 0;
        this.isFinish = false;
    }

    private void initColors()
    {
        for (int i = 0; i < this.buttonsCount; i++)
        {
            this.buttonGameobject[i].Find("Button_Outer_Ring").gameObject.GetComponent<Renderer>().material.SetColor("_BaseColor", this.sandWalk.getColors()[i]);
        }
    }
    private void initSequence(int size)
    {
        this.sequence.Clear();
        Debug.Log("Sequence: ");
        for (int i = 0; i < size; i++)
        {
            this.sequence.Add(Random.Range(0, this.buttonsCount));
            Debug.Log(this.sequence[i]);
        }
    }
    private void nextSequence()
    {
        if (this.sequence.Count >= this.startSequenzNumber + this.sequenceRepetition)
        {
            this.finishStage();
            return;
        }

        this.indexSequence = 0;
        for (int i = 0; i < this.step; i++) {
            this.sequence.Add(Random.Range(0, this.buttonsCount));
        }
        this.slideWormScript.repetitionSuccess();
        this.sandWalk.StartAnimation();
        Debug.Log(this.sequence[this.sequence.Count - 1]);
    }
    public bool checkSuccess(int buttonNumber)
    {
        if (this.isFinish) return false;

        if (this.sequence[this.indexSequence] == buttonNumber)
        {
            this.indexSequence++;
            if (this.indexSequence >= this.sequence.Count)
            {
                this.nextSequence();
            }
            return true;
        }
        this.slideWormScript.buttonFailed();
        return false;
    }
    private void disableButtons()
    {
        foreach (ButtonScript button in this.buttonS)
        {
            button.enabled = false;
        }
    }
    private void enableButtons()
    {
        foreach (ButtonScript button in this.buttonS)
        {
            button.enabled = true;
        }
    }
    private void finishStage()
    {
        this.isFinish = true;
        this.sandWalk.nextStage();
    }
    public int[] getSequence() {
        return this.sequence.ToArray();
    }
}
