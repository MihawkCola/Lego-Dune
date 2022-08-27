using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestroyExplosion : MonoBehaviour
{
    private Transform stones;
    [SerializeField] private float power;
    [SerializeField] private float radius;
    [SerializeField] private float upwardsModifier;

    private GameObject coinEploxionG;

    private NavMeshObstacle obstacle;
    public bool dissolve = true;

    void Start()
    {
        this.stones = this.transform.parent.Find("Stones");
        if (this.stones == null) Debug.Log("Es gibt kein objekt \"Stones\"");

        coinEploxionG = this.transform.parent.Find("CoinExplosion").gameObject;

        this.obstacle = GetComponent<NavMeshObstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Waffe") return;

        foreach (Transform stone in stones) 
        {
            stone.gameObject.layer = LayerMask.NameToLayer("Ignore Player");
            Rigidbody rb = stone.gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.01f;
                
            Vector3 localPosFromHit = this.transform.position - other.transform.position;
            localPosFromHit.y = 0;
            if (rb != null)
                rb.AddExplosionForce(this.power, this.transform.position - localPosFromHit.normalized, this.radius, this.upwardsModifier);

            if (dissolve)
            {
                StoneDissolve stoneDissolve = stone.gameObject.AddComponent<StoneDissolve>();
                stoneDissolve.start(1f, 6f);
            }
        }

        this.obstacle.enabled = false;

        if (coinEploxionG != null)
            Destroy(coinEploxionG);
        Destroy(this.gameObject);
    }
}
