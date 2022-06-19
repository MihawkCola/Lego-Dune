using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    private SandWalk sandWalk;
    private void Start()
    {
        sandWalk = this.transform.parent.GetComponent<SandWalk>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        sandWalk.StartGame();
    }
}
