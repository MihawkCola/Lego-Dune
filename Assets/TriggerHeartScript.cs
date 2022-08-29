using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHeartScript : MonoBehaviour
{
    private GameObject hud;
    private AudioSource ploppSound;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("HUD");
        ploppSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        PlayerControl playerControl = other.GetComponent<PlayerControl>();
        if (!playerControl.getActive()) return;

        this.GetComponent<MeshRenderer>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;

        ploppSound.Play();
        other.GetComponent<HealthScript>().increaseHealth();

        StartCoroutine(destroySelf());

    }
    private IEnumerator destroySelf()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (!ploppSound.isPlaying)
                Destroy(this.gameObject);
        }
    }
}
