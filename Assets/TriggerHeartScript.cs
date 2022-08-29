using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHeartScript : MonoBehaviour
{
    private AudioSource ploppSound;
    // Start is called before the first frame update
    void Start()
    {
        ploppSound = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        PlayerControl playerControl = other.GetComponent<PlayerControl>();
        if (!playerControl.getActive()) return;

        GameObject heartGameobject = this.transform.parent.gameObject;
        this.GetComponent<Collider>().enabled = false;

        ploppSound.Play();
        other.GetComponent<HealthScript>().increaseHealth();

        this.transform.parent = null;
        Destroy(heartGameobject);
        StartCoroutine(destroySelf());
        //Destroy(this.gameObject);

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
