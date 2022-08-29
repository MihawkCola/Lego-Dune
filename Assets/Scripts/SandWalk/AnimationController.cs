using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private float startSpawnDelay;

    private SandWalk sandWalk;
    private SwitchPlayer playerC;
    private Camera cam;
    private Animator wormAnimator;

    private Color[] colors;
    private int[] sequence;
    private int index = 0;

    private Vector3 notePosition;

    private AudioSource singingSound;

    private EnemyController enemyController;
    private void Awake()
    {
        this.enemyController = GameObject.Find("EnemyManager").GetComponent<EnemyController>();
        this.sandWalk = this.transform.parent.GetComponent<SandWalk>();
        this.playerC = GameObject.Find("Players").GetComponent<SwitchPlayer>();
        this.cam = this.transform.Find("Camera").GetComponent<Camera>();
        this.notePosition = this.transform.Find("NotePosition").transform.position;
        this.wormAnimator = this.GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        this.colors = this.sandWalk.getColors();
        singingSound = GetComponent<AudioSource>();
    }
    public void StartAnimation()
    {
        this.enemyController.disableAll();
        this.index = 0;
        this.sandWalk.StopSlide();
        this.playerC.disableCamera(cam);
        singingSound.Play();
        this.wormAnimator.SetBool("isSing", true);
        this.sequence = this.sandWalk.getActiveStageSequence();

        this.Invoke("nextNote", this.startSpawnDelay);
    }

    public void nextNote() 
    {
        if (this.index >= this.sequence.Length)
        {
            this.EndAnimation();
            return;
        }
            
        this.spawnNote();
        index++;
    }
    private void spawnNote() 
    {
        GameObject note = Instantiate(notePrefab, notePosition, Quaternion.identity);
        note.transform.parent = this.transform;

        Transform musicalNoteCircle = note.transform.Find("MusicalNoteCircle");
        musicalNoteCircle.transform.LookAt(cam.transform.position);
        musicalNoteCircle.transform.Rotate(0, 90, 0);

        Transform musicalNoteMain = note.transform.Find("MusicalNoteMain");

        var main = musicalNoteMain.GetComponent<ParticleSystem>();

        if (this.index >= this.sequence.Length) return;
        main.startColor = this.colors[this.sequence[index]];
    }
    public void EndAnimation()
    {
        this.enemyController.enableAll();
        this.playerC.activateCamera(cam);
        this.wormAnimator.SetBool("isSing", false);
        this.sandWalk.StartSlide();
    }

}
