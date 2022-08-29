using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Transform stones;
    [SerializeField] private float power;
    [SerializeField] private float radius;
    [SerializeField] private float upwardsModifier;
    [SerializeField] private Transform rig;
    [SerializeField] private Transform[] spezialInRig;

    [SerializeField] private GameObject gameobjectAi;

    private GameObject coinEploxionG;
    private EnemyInterface enemy;


    void Start()
    {
        this.stones = this.transform.parent.Find("Stones");
        if (this.stones == null) Debug.Log("Es gibt kein objekt \"Stones\"");

        coinEploxionG = this.transform.parent.Find("CoinExplosion").gameObject;

        this.enemy = this.gameobjectAi.GetComponent<EnemyInterface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Waffe") return;
        foreach (Transform spezial in spezialInRig) {
            spezial.parent = this.stones;
            prepareSpezial(spezial);
        }


        foreach (Transform stone in stones)
        {
            if (stone == rig) {
                stone.gameObject.SetActive(false);
                continue;
            }

            prepareStone(stone);
            stone.gameObject.layer = LayerMask.NameToLayer("Ignore Player");
            Rigidbody rb = stone.gameObject.AddComponent<Rigidbody>();
            rb.mass = 0.01f;

            Vector3 localPosFromHit = this.transform.position - other.transform.position;
            localPosFromHit.y = 0;
            if (rb != null)
                rb.AddExplosionForce(this.power, this.transform.position - localPosFromHit.normalized, this.radius, this.upwardsModifier);
        }
        this.enemy.setDeath();

        if (coinEploxionG != null)
            Destroy(coinEploxionG);
        Destroy(this.gameObject);
    }

    private void prepareSpezial(Transform spezial)
    {
        MeshCollider meshCollider = spezial.GetComponent<MeshCollider>();
        if (meshCollider != null) {
            meshCollider.isTrigger = false;
        }
        spezial.tag = "Untagged";
    }
    private void prepareStone(Transform stone)
    {
        SkinnedMeshRenderer skinnedMeshRenderer = stone.GetComponent<SkinnedMeshRenderer>();



        if(skinnedMeshRenderer != null)
        {
            //skinnedMeshRenderer.material;
            MeshRenderer newMeshRenderer = stone.gameObject.AddComponent<MeshRenderer>();
            newMeshRenderer.sharedMaterial = skinnedMeshRenderer.material;
            skinnedMeshRenderer.enabled = false;
        }
            

        MeshCollider meshCollider = stone.GetComponent<MeshCollider>();
        if (meshCollider != null)
            meshCollider.enabled = true;

        MeshRenderer meshRenderer = stone.GetComponent<MeshRenderer>();
        if (meshRenderer != null)
            meshRenderer.enabled = true;
    }
}
