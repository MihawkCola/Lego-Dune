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
    [SerializeField] private float probabilityHeart;

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
        if (this.coinController == null) return;
        this.coinController.multiCoinsExplosion(explosionDelay, beetwenDelay, this.transform.position, numberPurple, numberBlue, numberGold, numberSilver, probabilityHeart);
    }
}
