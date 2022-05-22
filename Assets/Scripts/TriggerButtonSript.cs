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

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (timer > TriggerTime)
        {
            Debug.Log("Trigger");
            animator.SetBool("isTrigger", true);
        }
        else {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.timer = 0;
    }
    public void reset()
    {
        animator.SetBool("isTrigger", false);
        //this.GetComponentInChildren<Renderer>().material.SetColor("_Color", Color.white);
    }
    public bool IsTrigger() {
        return animator.GetBool("isTrigger");
    }

}
