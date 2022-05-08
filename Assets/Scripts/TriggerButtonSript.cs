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

    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (timer > TriggerTime)
        {
            mr.material = TriggerMaterial;
            isTrigger = true;
            Debug.Log("Trigger");
            animator.SetBool("isTrigger",true);
        }
        else {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        this.timer = 0;
    }
    private void reset()
    {
        isTrigger = false;
        mr.material = DefaultMaterial;
    }
    public bool IsTrigger() {
        return isTrigger;
    }
}
