using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneLerp : MonoBehaviour
{
    private Transform target;
    private bool build = false;
    // Update is called once per frame
    void Update()
    {
        if (!build) return;

        this.transform.position = Vector3.Lerp(this.transform.position, target.position, 2f * Time.deltaTime);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target.rotation, 2f * Time.deltaTime);
        Debug.Log(this.name);
        Debug.Log(Vector3.Lerp(this.transform.position, target.position, 2f * Time.deltaTime));
    }
    public void goToTarget(Transform target)
    {
        this.target = target;
        build = true;
    }
}
