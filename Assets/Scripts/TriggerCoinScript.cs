using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoinScript : MonoBehaviour
{

    private GameObject hud;
    private int value;

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
                value = 0;
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hud.GetComponent<CoinsScript>().increaseCoinAmount(value);
            Destroy(gameObject);
        }
    }
}
