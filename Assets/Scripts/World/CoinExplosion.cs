using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinExplosion : MonoBehaviour
{
    [SerializeField] private float explosionDelay;
    [SerializeField] private float beetwenDelay;

    [SerializeField] private int numberPurple;
    [SerializeField] private int numberBlue;
    [SerializeField] private int numberGold;
    [SerializeField] private int numberSilver;

    private CoinController coinController;

    private void Start()
    {
        GameObject gameObjectCoins = GameObject.Find("CoinController");
        if (gameObject != null)
            coinController = gameObjectCoins.GetComponent<CoinController>();
        else
            Debug.Log("Es wurde kein CoinController gefunden");
    }
    private void OnDestroy()
    {
        this.coinController.multiCoinsExplosion(explosionDelay, beetwenDelay, this.transform.position, numberPurple, numberBlue, numberGold, numberSilver);
    }
}
