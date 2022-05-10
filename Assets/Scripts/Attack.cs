using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private int attackcounter = 0;

    [SerializeField] private Material changeMaterial;
    // Start is called before the first frame update
    MeshRenderer meshRenderer;
    void Start()
    {
        GameObject obj = this.transform.parent.gameObject;
        meshRenderer = obj.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Waffe") return;
        Debug.Log("Attackcounter: " + ++attackcounter);

        if(changeMaterial != null) meshRenderer.material = changeMaterial;
 
    }
}
