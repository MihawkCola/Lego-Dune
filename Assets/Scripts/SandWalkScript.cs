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
    private int[] sequence = new int[3];
    private int next = 0;
    public Slider slider;
    private GameObject lastButton0;
    private GameObject lastButton;


    // Start is called before the first frame update
    void Start()
    {
        lastButton0 = lastButton = buttons[0];
        slider.value = 1;
        setColors();
        generateSequence();
        generateColors();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (next == cubes.Length)
        {
            generateSequence();
            generateColors();
            buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            next = 0;
        }
        /*if (next == 0 && buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().IsTrigger())
        {
            buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
        }
        if (buttons[sequence[next]].GetComponentInChildren<TriggerButtonSript>().IsTrigger())
        {
            slider.value += 0.1f;
            cubes[next].GetComponent<Image>().color = Color.clear;
            if (next > 0)
            {
                buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            }
            next++;

        }*/
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
            /*if (next > 0)
            {
                buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            }*/
            next++;
            

        } else
        {
            Debug.Log("else: " + triggerButtonSript.getNumber());
            if (slider.value - 0.2f <0 )
            {
                slider.value = 0;
            }
            else
            {
                slider.value -= 0.2f;
            }
            //triggerButtonSript.reset();
        }
    }

    internal void buttonNotTriggered(TriggerButtonSript triggerButtonSript)
    {
        if (next == cubes.Length)
        {
            generateSequence();
            generateColors();
            //buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            next = 0;
        }
    }


    private IEnumerator wait()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            slider.value -= 0.01f;
            /*if (next == 0 && lastButton.GetComponentInChildren<TriggerButtonSript>().IsTrigger())
            {
                lastButton.GetComponentInChildren<TriggerButtonSript>().reset();
            }*/
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
        lastButton = lastButton0;
        sequence = getRandomSequence(3, 3);
        for (int i = 0; i < sequence.Length; i++)
        {
            buttons[sequence[i]].GetComponentInChildren<TriggerButtonSript>().setNumber(i);
            if(sequence[i] == sequence.Length - 1)
            {
                lastButton0 = buttons[i];
            }
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
        int[] chosenColors = getRandomSequence(cubes.Length, colors.Length);
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].GetComponent<Image>().color = colors[chosenColors[i]];
            // eigtl. Button_Tile_Flat
            buttons[sequence[i]].transform.Find("Button_Outer_Ring").gameObject.GetComponent<Renderer>().material.SetColor("_Color", colors[chosenColors[i]]);
        }

    }
}
