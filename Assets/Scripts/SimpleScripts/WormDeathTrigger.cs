using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Transform figure = other.transform.Find("Figure");

        if (figure == null) return;
        figure.gameObject.SetActive(false);
    }
}
