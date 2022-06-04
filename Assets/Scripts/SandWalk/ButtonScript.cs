using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private Animator animator;
    private Step step;
    private int number;

    void Awake()
    {
        this.animator = this.transform.GetComponent<Animator>();
    }

    void Start()
    {
        step = this.GetComponentInParent<Step>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isFailed", true);
    }
    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isFailed", false);
    }
    public void reset()
    {
        animator.SetBool("isFailed", false);
        animator.SetBool("isSucces", false);
    }
    public bool IsTrigger()
    {
        animator.SetBool("isSucces", true);
        return animator.GetBool("isSucces");
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
