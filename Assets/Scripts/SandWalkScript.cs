using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandWalkScript : MonoBehaviour
{

    public GameObject[] buttons;
    public Image[] cubes;
    private Color[] colors;
    int[] chosenColors;
    private int[] sequence = new int[3];
    private int next = 0;
    public Slider slider;
    public ParticleSystem particleSys;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        slider.value = 1;
        setColors();
        generateSequence();
        generateColors();
        var main = particleSys.main;
        main.startColor = colors[chosenColors[next]];
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
    }

    internal void setPlayer(GameObject player)
    {
        this.player = player;
    }

    internal void buttonTriggered(TriggerButtonSript triggerButtonSript)
    {
        Debug.Log("nr: " + triggerButtonSript.getNumber());

        

        if (triggerButtonSript.getNumber() == next)
        {
            Debug.Log("if: " + triggerButtonSript.getNumber());
            if(slider.value + 0.2f > 1)
            {
                slider.value = 1;
            }
            else
            {
                slider.value += 0.2f;
            }
            cubes[next].GetComponent<Image>().color = Color.clear;
            next++;
            
        } else
        {
            Debug.Log("else: " + triggerButtonSript.getNumber());
            if (slider.value - 0.2f <0 )
            {
                slider.value = 0;
                //player.GetComponent<HealthScript>().decreaseHealth();
            }
            else
            {
                slider.value -= 0.2f;
            }
        }
    }

    internal void buttonNotTriggered(TriggerButtonSript triggerButtonSript)
    {
        if (next == cubes.Length)
        {
            generateSequence();
            generateColors();
            next = 0;
        }
    }

    private IEnumerator wait()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            if (slider.value - 0.05f < 0)
            {
                slider.value = 0;
                GameObject.Find("PlayerPaul").gameObject.GetComponent<HealthScript>().decreaseHealth();
                //player.GetComponent<HealthScript>().decreaseHealth();
            }
            else
            {
                slider.value -= 0.05f;
            }
        }
    }

    private void setColors()
    {
        colors = new Color[12];
        colors[0] = new Color32(255, 0, 0, 255);
        colors[1] = new Color32(0, 255, 0, 255);
        colors[2] = new Color32(0, 0, 255, 255);
        colors[3] = new Color32(100, 100, 0, 255);
        colors[4] = new Color32(0, 100, 100, 255);
        colors[5] = new Color32(100, 0, 100, 255);
        colors[6] = new Color32(50, 25, 25, 255);
        colors[7] = new Color32(25, 50, 25, 255);
        colors[8] = new Color32(25, 25, 50, 255);
        colors[9] = new Color32(255, 255, 0, 255);
        colors[10] = new Color32(0, 255, 255, 255);
        colors[11] = new Color32(255, 0, 255, 255);
    }

    private void generateSequence()
    {
        sequence = getRandomSequence(3, 3);
        for (int i = 0; i < sequence.Length; i++)
        {
            buttons[sequence[i]].GetComponentInChildren<TriggerButtonSript>().setNumber(i);
        }
    }

    private int[] getRandomSequence(int wanted, int range)
    {
        int[] erg = new int[wanted];
        int pos;
        List<int> list = new List<int>();
        for (int i = 0; i < range; i++)
        {
            list.Add(i);
        }
        for (int i = 0; i < wanted; i++)
        {
            pos = UnityEngine.Random.Range(0, list.Count);
            erg[i] = list[pos];
            list.RemoveAt(pos);
        }
        return erg;
    }
    private void generateColors()
    {
        Debug.Log(cubes.Length);
        chosenColors = getRandomSequence(cubes.Length, colors.Length);
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].GetComponent<Image>().color = colors[chosenColors[i]];
            // eigtl. Button_Tile_Flat
            buttons[sequence[i]].transform.Find("Button_Outer_Ring").gameObject.GetComponent<Renderer>().material.SetColor("_Color", colors[chosenColors[i]]);
        }

    }
}
