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
    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        this.InputOn();
        coinAmount = 0;
        increaseCoinAmount(0);
    }

    public void increaseCoinAmount(int coins)
    {
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
        inputs.Player.CoinsPlus.started += coinsP;
        inputs.Player.CoinsMinus.started += coinsM;
    }

    public void InputOff()
    {
        inputs.Player.CoinsPlus.started -= coinsP;
        inputs.Player.CoinsMinus.started -= coinsM;
    }

    private void coinsP(InputAction.CallbackContext obj)
    {
        increaseCoinAmount(99);
    }

    private void coinsM(InputAction.CallbackContext obj)
    {
        decreaseCoinAmount(99);
    }

    public int getCoinAmount()
    {
        return coinAmount;
    }
}
