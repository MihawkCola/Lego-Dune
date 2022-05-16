using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class CoinsScript : MonoBehaviour
{
    private PlayerInput inputs;

    public Image coinLeft;
    public Image coinRight;
    public Text coinText;
    public int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        increaseCoinAmount(100);
    }

    public void increaseCoinAmount(int coins)
    {
        Debug.Log("Click"+coins);
        coinAmount += coins;
        coinText.GetComponent<Text>().text = coinAmount.ToString();
        coinLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-coinText.GetComponent<RectTransform>().sizeDelta.x/2 - coinLeft.GetComponent<RectTransform>().sizeDelta.x/2, -18);
        coinRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(coinText.GetComponent<RectTransform>().sizeDelta.x/2 + coinRight.GetComponent<RectTransform>().sizeDelta.x/2, -18);
       
    }

    public void decreaseCoinAmount(int coins)
    {
        coinAmount = (coinAmount - coins >= 0) ? coinAmount - coins : 0;
        coinText.GetComponent<Text>().text = coinAmount.ToString();
        coinLeft.GetComponent<RectTransform>().anchoredPosition = new Vector2(-coinText.GetComponent<RectTransform>().sizeDelta.x / 2 - coinLeft.GetComponent<RectTransform>().sizeDelta.x / 2, -18);
        coinRight.GetComponent<RectTransform>().anchoredPosition = new Vector2(coinText.GetComponent<RectTransform>().sizeDelta.x / 2 + coinRight.GetComponent<RectTransform>().sizeDelta.x / 2, -18);

    }

    public void InputOn()
    {
        inputs.Player.Coins.started += coins;
    }


    public void InputOff()
    {
        inputs.Player.Coins.started -= coins;
    }

    private void coins(InputAction.CallbackContext obj)
    {
        Debug.Log("hier!");
        increaseCoinAmount(10);
    }
}
