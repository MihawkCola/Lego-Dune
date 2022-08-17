using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoinScript : MonoBehaviour
{

    private GameObject hud;
    private int value;
    AudioSource coinSound;

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
        coinSound.Play();

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            coinSound.Play();
            hud.GetComponent<CoinsScript>().increaseCoinAmount(value);
            Destroy(this.transform.parent.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
