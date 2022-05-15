
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour
{
    public Image[] healthHearts;
    public int health;
    private PlayerInput inputs;


    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        resetHealth();
        /*decreaseHealth();
        decreaseHealth();

        decreaseHealth();
        increaseHealth();
        increaseHealth();
        resetHealth();*/

    }

    void increaseHealth() { 
        if(health < healthHearts.Length)
        {
            healthHearts[health - 1].GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
            healthHearts[health - 1].GetComponent<Animator>().enabled = false;
            healthHearts[health].gameObject.SetActive(true);
            healthHearts[health].GetComponent<Animator>().enabled = true;
            health++;
        }
    }

    void decreaseHealth() {
        if (health > 0)
        {
            health--;
            healthHearts[health].GetComponent<Animator>().enabled = false;
            healthHearts[health].GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
            healthHearts[health].gameObject.SetActive(false);
            if(health != 0)
            {
                healthHearts[health - 1].GetComponent<Animator>().enabled = true;
            }
        }
    }

    void resetHealth() {
        foreach (Image img in healthHearts)
        {
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
            img.gameObject.SetActive(true);
            img.GetComponent<Animator>().enabled = false;
        }
        healthHearts[healthHearts.Length - 1].GetComponent<Animator>().enabled = true;
    }

    public void InputOn()
    {
        inputs.Player.IncreaseHealth.started += increase;
        inputs.Player.DecreaseHealth.started += decrease;
    }


    public void InputOff()
    {
        inputs.Player.IncreaseHealth.started -= increase;
        inputs.Player.DecreaseHealth.started -= decrease;

    }

    private void increase(InputAction.CallbackContext obj)
    {
        increaseHealth();
    }

    private void decrease(InputAction.CallbackContext obj)
    {
        decreaseHealth();
    }


    // Update is called once per frame
    void Update()
    {
        //decreaseHealth();
       
    }
}
