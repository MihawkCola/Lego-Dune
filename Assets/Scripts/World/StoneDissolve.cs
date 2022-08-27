using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDissolve : MonoBehaviour
{
    private float startTime = float.MaxValue;

    private float startTimeDissolve;
    private Vector3 startScale;

    private float duration = 2f;
    private bool firstTime = true;

    private void Start()
    {
        this.startScale = transform.localScale;
    }
    private void Update()
    {
        if (this.startTime < Time.time) dissolveStone();
    }

    public void dissolveStone() {
        if (firstTime) {
            this.startTimeDissolve = Time.time;
            firstTime = false;
        }

        this.transform.localScale = startScale * (duration - timeFromStart()) / duration;
        if (this.transform.localScale.magnitude < 0.01f)
            Destroy(this.gameObject);
    }

    private float timeFromStart() {
        float time = Time.time - startTimeDissolve;
        if(time > duration)
            return duration;
        return time;
    }
    public void start(float duration, float delay)
    {
        this.duration = duration;
        this.startTime = Time.time + delay;
    }
}
