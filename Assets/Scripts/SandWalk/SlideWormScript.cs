using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideWormScript : MonoBehaviour
{
    private Transform players;
    private Slider slider;
    [SerializeField] private float decreaseValueOverTime;
    [SerializeField] private float decreaseValueFailed;
    [SerializeField] private float successValueRepetition;
    [SerializeField] private float slideRate;

    private Coroutine coroutine;
    private HealthController healthController;
    void Awake()
    {
        // sollte über ein HUD Controller geholt werden
        this.slider = GameObject.Find("HUD").transform.Find("Slider").GetComponent<Slider>();
        this.slider.value = 1;
    }
    private void Start()
    {
        this.players = GameObject.Find("Players").transform;
        this.healthController = this.players.GetComponent<HealthController>();
    }
    private void OnEnable()
    {
        coroutine = this.StartCoroutine(this.timeDecrease());
        //this.slider.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        this.StopCoroutine(coroutine);
        //this.slider.gameObject.SetActive(false);
    }
    public void decreaseSlider(float decrease) 
    {
        if (slider.value - decrease < 0) 
        {
            slider.value = 1;
            bool allDeath = this.players.GetComponent<HealthController>().decreaseHealthAll(DamageTyp.Worm);
            if(allDeath) this.gameObject.SetActive(false);
            //ToDo SandWalk soll die Noten neue zeigen und reset Sequence Reihenfolge
            return;
        }

        slider.value -= decrease;
    }
    public void increaseSlider(float increase)
    {
        if (slider.value + increase > 1)
        {
            slider.value = 1;
            return;
        }

        slider.value += increase;
    }
    private void Reset()
    {
        this.resetValue();
    }
    public void resetValue() 
    {
        slider.value = 1;
    }

    private IEnumerator timeDecrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(slideRate);
            this.decreaseSlider(this.decreaseValueOverTime);
        }
    }
    public void buttonFailed() 
    {
        this.decreaseSlider(this.decreaseValueFailed);
    }
    public void repetitionSuccess()
    {
        this.increaseSlider(this.successValueRepetition);
    }

}
