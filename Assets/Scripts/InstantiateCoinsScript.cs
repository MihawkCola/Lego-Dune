using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoinsScript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject blueCoin;
    public GameObject goldCoin;
    public GameObject silverCoin;
    public GameObject purpleCoin;
    private int blueCoinAmount;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(blueCoin, new Vector3(0, 0, 0), Quaternion.identity);

        /*blueCoinAmount = 100;

        for (int x = 0; x < blueCoinAmount; ++x)
        {
            Instantiate(blueCoin, new Vector3(5.0f, 0.4f, 2.0f), Quaternion.identity);
            //Instantiate(goldCoin, new Vector3(5.0f, 0.4f, 3.0f), Quaternion.identity);
            //Instantiate(silverCoin, new Vector3(5.0f, 0.4f, 1.0f), Quaternion.identity);
            //Instantiate(purpleCoin, new Vector3(5.0f, 0.4f, 4.0f), Quaternion.identity);
        }*/
        this.StartCoroutine(this.spawn());

    }
    private IEnumerator spawn()
    {
        Debug.Log("test");
        yield return new WaitForSeconds(2);
        Debug.Log("test");
        blueCoinAmount = 100;
        for (int x = 0; x < blueCoinAmount; ++x)
        {
            Instantiate(blueCoin, this.transform.position, Quaternion.identity);
            //Instantiate(goldCoin, new Vector3(5.0f, 0.4f, 3.0f), Quaternion.identity);
            //Instantiate(silverCoin, new Vector3(5.0f, 0.4f, 1.0f), Quaternion.identity);
            //Instantiate(purpleCoin, new Vector3(5.0f, 0.4f, 4.0f), Quaternion.identity);
        }
    }

}
