using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    private Transform stones;
    [SerializeField] private float power;
    [SerializeField] private float radius;
    [SerializeField] private float upwardsModifier;

    void Start()
    {
        this.stones = this.transform.parent.Find("Stones");
        if (this.stones == null) Debug.Log("Es gibt kein objekt \"Stones\"");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Waffe") return;

        foreach (Transform stone in stones) 
        { 
            Rigidbody rb = stone.gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.01f;
            stone.gameObject.layer = LayerMask.NameToLayer("Ignore Player");

            Vector3 localPosFromHit = this.transform.position - other.transform.position;
            localPosFromHit.y = 0;
            if (rb != null)
                rb.AddExplosionForce(this.power, this.transform.position - localPosFromHit.normalized, this.radius, this.upwardsModifier);
        }
        this.GetComponent<Collider>().enabled = false;
    }
}
