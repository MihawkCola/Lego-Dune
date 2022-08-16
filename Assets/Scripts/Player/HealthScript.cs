
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthScript : MonoBehaviour
{
    public Image[] healthHearts;
    public int health;
    private PlayerInput inputs;

    private GameObject wormObeject;
    private Animator wormAnimator;

    public bool activeDeath = false;
    public Camera deathCam;
    
    private SwitchPlayer playerScript;
    
    [SerializeField] private GameObject playerModel;

    private AudioSource[] sounds;
    AudioSource deathSound;
    AudioSource hitSound;

    void Start()
    {
        inputs = GameObject.Find("PlayerInput").GetComponent<InputScript>().getPlayerInput();
        this.InputOn();
        resetHealth();

        this.wormObeject = this.transform.Find("LEGOWormAnimations").gameObject;
        this.wormAnimator = wormObeject.GetComponent<Animator>();
        
        this.playerScript = this.transform.parent.GetComponent<SwitchPlayer>();

        sounds = GetComponents<AudioSource>();
        deathSound = sounds[1];
        hitSound = sounds[0];

    }

    void increaseHealth() { 
        if(health < healthHearts.Length)
        {
            health++;
            if(health > 1)
            {
                healthHearts[health - 2].GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
                healthHearts[health - 2].GetComponent<Animator>().enabled = false;
            }
            healthHearts[health - 1].gameObject.SetActive(true);
            healthHearts[health - 1].GetComponent<Animator>().enabled = true;
        }
    }

    public void decreaseHealth() {
        if (health > 0)
        {
            health--;
            healthHearts[health].GetComponent<Animator>().enabled = false;
            healthHearts[health].GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
            healthHearts[health].gameObject.SetActive(false);
            if (health != 0)
            {
                healthHearts[health - 1].GetComponent<Animator>().enabled = true;
                hitSound.Play();
            }
            else {
                this.death();
            }
        }

    }

    private void death()
    {
        if (!activeDeath) return;

        this.playerScript.disableCamera(this.deathCam);

        wormObeject.SetActive(true);
        wormObeject.transform.parent = null;
        wormAnimator.SetTrigger("death");
        deathSound.Play();
        StartCoroutine(resetLevel());
    }
    private IEnumerator resetLevel() {
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resetHealth() {
        foreach (Image img in healthHearts)
        {
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
            img.gameObject.SetActive(true);
            img.GetComponent<Animator>().enabled = false;
        }
        healthHearts[healthHearts.Length - 1].GetComponent<Animator>().enabled = true;
        health = healthHearts.Length;

    }

    public void InputOn()
    {
        inputs.Player.IncreaseHealth.started += increase;
        inputs.Player.DecreaseHealth.started += decrease;
        inputs.Player.ResetHealth.started += reset;

    }

    

    public void InputOff()
    {
       
        inputs.Player.IncreaseHealth.started -= increase;
        inputs.Player.DecreaseHealth.started -= decrease;
        inputs.Player.ResetHealth.started -= reset;

    }

    private void increase(InputAction.CallbackContext obj)
    {
        Debug.Log("icrease");

        increaseHealth();
    }

    private void decrease(InputAction.CallbackContext obj)
    {
        Debug.Log("decrease");

        decreaseHealth();
    }

    private void reset(InputAction.CallbackContext obj)
    {
        Debug.Log("reset");

        resetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //decreaseHealth();
       
    }
}
