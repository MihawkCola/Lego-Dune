using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLerp : MonoBehaviour
{
    private Transform target;
    private bool build = false;
    private int indexStone;
    private BuildController buildController;

    private float speed = 2f;
    
    void Update()
    {
        if (!build) return;

        this.transform.position = Vector3.Lerp(this.transform.position, target.position, this.speed * Time.deltaTime);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target.rotation, this.speed * Time.deltaTime);

        checkFinish();
    }

    private void checkFinish()
    {
        if (Vector3.Distance(this.transform.position, target.position) > 0.01f) return;
        target.gameObject.SetActive(true);

        this.buildController.checkLastStone(indexStone);
        this.build = false;
        this.enabled = false;
    }

    public void goToTarget(Transform target, int indexStone, BuildController buildController)
    {
        prepareStone();
        this.indexStone = indexStone;
        this.buildController = buildController;
        this.target = target;
        build = true;
    }
    public void goToTarget(Transform target, float speed, int indexStone, BuildController buildController)
    {
        this.speed = speed;
        this.goToTarget(target, indexStone, buildController);
    }
    private void prepareStone() {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (rb == null) return;
        Destroy(rb);
    }
}
