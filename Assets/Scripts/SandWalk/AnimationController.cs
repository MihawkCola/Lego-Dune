using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject testCube;

    private SandWalk sandWalk;
    private SwitchPlayer playerC;
    private Camera cam;
    private GameObject input;
    private Animator wormAnimator;

    private Color[] colors;
    private int[] sequence;

    private Vector3 notePosition;
    private void Awake()
    {
        this.sandWalk = this.transform.parent.GetComponent<SandWalk>();
        this.playerC = GameObject.Find("Players").GetComponent<SwitchPlayer>();
        this.cam = this.transform.Find("Camera").GetComponent<Camera>();
        this.input = GameObject.Find("PlayerInput");
        this.notePosition = this.transform.Find("NotePosition").transform.position;
        this.wormAnimator = this.GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        this.colors = this.sandWalk.getColors();
    }
    public void StartAnimation()
    {
        this.sandWalk.StopSlide();
        this.playerC.disableCamera(cam);
        this.input.SetActive(false);
        this.wormAnimator.SetBool("isSing", true);
        this.sequence = this.sandWalk.getActiveStageSequence();
        /*for (int i = 0; i < this.sequence.Length; i++) {
            Debug.Log(this.sequence[i]);
            Debug.Log(this.colors[this.sequence[i]]);
            this.testCube.GetComponent<Renderer>().material.SetColor("_Color", this.colors[this.sequence[i]]);
        }*/

        GameObject tmp = Instantiate(notePrefab, notePosition, Quaternion.identity);
        tmp.transform.parent = this.transform;

        var main  = tmp.transform.GetChild(0).GetChild(0).GetComponent<ParticleSystem>();
        main.startColor = this.colors[this.sequence[0]];
    }
    public void EndAnimation()
    {
        this.playerC.activateCamera(cam);
        this.sandWalk.StartSlide();
        this.input.SetActive(true);
    }

}
