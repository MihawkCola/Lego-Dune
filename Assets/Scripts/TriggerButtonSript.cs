using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerButtonSript : MonoBehaviour
{
    [SerializeField] private float TriggerTime = 0.5f;
    private float timer = 0;
    private Animator animator;

    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        animator.SetBool("isTrigger", true);
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
            animator.SetBool("isTrigger",false);
        }
        else {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.timer = 0;
    }
    private void Reset()
    {
        animator.SetBool("isTrigger", false);
    }
    public bool IsTrigger() {
        return animator.GetBool("isTrigger");
    }
}
