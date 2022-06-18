using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject blueCoin;
    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject purpleCoin;

    public enum Coin { Purple, Blue, Gold, Silver };

    private void Start()
    {
        this.StartCoroutine(this.spawnOverTime(2f,2f,this.transform.position,10,10,10,10));
        //spawnCoins(Coin.Blue, this.transform.position, 100);
    }
    public void spawnCoin(Coin coin, Vector3 point)
    {
        this.creatCoin(coin, point);
    }
    public GameObject creatCoin(Coin coin, Vector3 point)
    {
        GameObject tmp = silverCoin;

        if (coin == Coin.Purple)
            tmp = purpleCoin;
        else if (coin == Coin.Blue)
            tmp = blueCoin;
        else if (coin == Coin.Gold)
            tmp = goldCoin;

        return Instantiate(tmp, point, Quaternion.identity);
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
            Vector3 spawnPoint = point + Vector3.up * Random.Range(0f, 0.5f) + Vector3.forward * Random.Range(-0.4f,0.4f) + Vector3.right * Random.Range(-0.4f, 0.4f);
            GameObject coinO = this.creatCoin(coin, spawnPoint);
            Rigidbody rb = coinO.GetComponent<Rigidbody>();
            rb.AddExplosionForce(350 + Random.Range(0, 100), point, 5f, 1f);
           // yield return new WaitForSeconds(0.1f);
        }
    }
    private IEnumerator spawnOverTime(float startDelay, float betweenDelay, Vector3 point, int numberPurple, int numberBlue, int numberGold, int numberSilver)
    {
        yield return new WaitForSeconds(startDelay);
        coinExplosion(Coin.Purple, point, numberPurple);

        yield return new WaitForSeconds(startDelay);
        coinExplosion(Coin.Blue, point, numberBlue);

        yield return new WaitForSeconds(startDelay);
        coinExplosion(Coin.Gold, point, numberGold);

        yield return new WaitForSeconds(startDelay);
        coinExplosion(Coin.Silver, point, numberSilver);

    }
}
