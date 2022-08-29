using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator animator;
    private Stage stage;
    private int number;

    void Awake()
    {
        this.animator = this.transform.GetComponent<Animator>();
        stage = this.GetComponentInParent<Stage>();
    }
    private void OnDisable()
    {
        this.animator.SetBool("disable", true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
    private void OnEnable()
    {
        this.animator.SetBool("disable", false);
        this.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.animator.GetBool("isSuccess") || this.animator.GetBool("isFailed")) return;
            
        if (this.stage.checkSuccess(number))
        {
            animator.SetBool("isSuccess", true);
            GetComponents<AudioSource>()[0].Play();
        }
        else
        {
            animator.SetBool("isFailed", true);
            GetComponents<AudioSource>()[1].Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.reset();
    }
    public void reset()
    {
        animator.SetBool("isFailed", false);
        animator.SetBool("isSuccess", false);
    }
    public void setNumber(int n)
    {
        number = n;
    }
    public int getNumber()
    {
        return number;
    }
}
