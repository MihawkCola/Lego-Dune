using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButtonSript : MonoBehaviour
{
    [SerializeField] private float TriggerTime = 0.5f;
    [SerializeField] private Material TriggerMaterial = null;
    [SerializeField] private Material DefaultMaterial = null;
    private float timer = 0;
    private bool isTrigger = false;
    private Animator animator;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isTrigger", true);
        GetComponentInParent<SandWalkScript>().buttonTriggered(this);
    }
    /*private void OnTriggerStay(Collider other)
    {
        
        if (timer > TriggerTime) 
        {
            Debug.Log("Trigger");
            animator.SetBool("isTrigger", true);
            GetComponentInParent<SandWalkScript>().buttonTriggered(this);
        }
        else {
            timer += Time.deltaTime;
        }
    }*/
    private void OnTriggerExit(Collider other)
    {
        //this.timer = 0;
        animator.SetBool("isTrigger", false);
        GetComponentInParent<SandWalkScript>().buttonNotTriggered(this);
    }
    public void reset()
    {
        animator.SetBool("isTrigger", false);
    }
    public bool IsTrigger() {
        return animator.GetBool("isTrigger");
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
