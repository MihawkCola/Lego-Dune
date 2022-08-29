using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject blueCoin;
    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject purpleCoin;
    public GameObject heart;

    private Transform level = null;
    public enum Coin { Purple, Blue, Gold, Silver };

    AudioSource coinSound;


    private void Start()
    {
        if(GameObject.Find("Level") != null)
            this.level = GameObject.Find("Level").transform;
        //testen
        //this.StartCoroutine(this.spawnOverTime(2f,2f,this.transform.position,10,10,10,10));
        //spawnCoins(Coin.Blue, this.transform.position, 100);

        coinSound = GetComponent<AudioSource>();
    }
    public void spawnCoin(Coin coin, Vector3 point)
    {
        this.createCoin(coin, point);
    }
    public GameObject createCoin(Coin coin, Vector3 point)
    {
        GameObject tmp = silverCoin;

        if (coin == Coin.Purple)
            tmp = purpleCoin;
        else if (coin == Coin.Blue)
            tmp = blueCoin;
        else if (coin == Coin.Gold)
            tmp = goldCoin;

        GameObject coinG = Instantiate(tmp, point, Quaternion.identity);
        if(this.level != null)
            coinG.transform.parent = level.transform;
        return coinG;
    }
    public void spawnCoins(Coin coin, Vector3 point, int number)
    {
        for (int i = 0; i < number; i++)
        {
            this.spawnCoin(coin, point);
        }
    }

    public void coinExplosion(Coin coin, Vector3 point, int number) 
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 spawnPointOffset = Vector3.right * Random.Range(-0.4f, 0.4f) + Vector3.up * Random.Range(0f, 0.5f) + Vector3.forward * Random.Range(-0.4f, 0.4f);
            Vector3 newPoint = point + spawnPointOffset;

            GameObject coinO = this.createCoin(coin, newPoint);
            Rigidbody rb = coinO.GetComponent<Rigidbody>();
            rb.AddExplosionForce(250 + Random.Range(0, 100), newPoint, 5f, 1f);
            coinSound.Play();
        }
    }
    private IEnumerator spawnOverTime(float startDelay, float betweenDelay, Vector3 point, int numberPurple, int numberBlue, int numberGold, int numberSilver, float probabilityHeart)
    {
        yield return new WaitForSeconds(startDelay);

        if(probabilityHeart >= Random.Range(0.0f, 1.0f))
        {
            Instantiate(heart, point, Quaternion.identity); 
            yield return new WaitForSeconds(betweenDelay);
        }
        
        if (numberSilver != 0) {
            coinExplosion(Coin.Silver, point, numberSilver);
            yield return new WaitForSeconds(betweenDelay);
        }

        if (numberGold != 0) 
        {
            coinExplosion(Coin.Gold, point, numberGold);
            yield return new WaitForSeconds(betweenDelay);
        }

        if (numberBlue != 0) 
        {
            coinExplosion(Coin.Blue, point, numberBlue);
            yield return new WaitForSeconds(betweenDelay);
        }


        coinExplosion(Coin.Purple, point, numberPurple);

        

    }
    public void multiCoinsExplosion(float startDelay, float betweenDelay, Vector3 point, int numberPurple, int numberBlue, int numberGold, int numberSilver, float probabilityHeart) 
    {
        this.StartCoroutine(this.spawnOverTime(startDelay, betweenDelay, point, numberPurple, numberBlue, numberGold, numberSilver, probabilityHeart));
    }
}
