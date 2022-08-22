using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoinScript : MonoBehaviour
{

    private GameObject hud;
    private int value;
    private AudioSource coinSound;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("HUD");

        switch (gameObject.tag)
        {
            case "BlueCoin":
                value = 1000;
                break;
            case "GoldCoin":
                value = 100;
                break;
            case "SilverCoin":
                value = 10;
                break;
            case "PurpleCoin":
                value = 10000;
                break;
            default:
                value = 1;
                break;
        }
        coinSound = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject coinGameobject = this.transform.parent.gameObject;
            this.GetComponent<Collider>().enabled = false;

            coinSound.Play();
            hud.GetComponent<CoinsScript>().increaseCoinAmount(value);


            this.transform.parent = null;
            Destroy(coinGameobject);
            StartCoroutine(destroySelf());
            //Destroy(this.gameObject);
        }
    }
    private IEnumerator destroySelf()
    {
        while (true) {
            yield return new WaitForSeconds(1f);
            if(!coinSound.isPlaying)
                Destroy(this.gameObject);
        }
    }

}
