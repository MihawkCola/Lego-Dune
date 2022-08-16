using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDeathTrigger : MonoBehaviour
{

    private AudioSource[] sounds;
    AudioSource deathSound;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        deathSound = sounds[1];
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player") return;
        Transform figure = other.transform.Find("Figure");

        if (figure == null) return;
        figure.gameObject.SetActive(false);
        deathSound.Play();

    }
}
