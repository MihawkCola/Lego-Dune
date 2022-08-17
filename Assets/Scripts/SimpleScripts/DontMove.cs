using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<SecondPlayerAi>().notWalk = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        other.GetComponent<SecondPlayerAi>().notWalk = false;
    }
}
