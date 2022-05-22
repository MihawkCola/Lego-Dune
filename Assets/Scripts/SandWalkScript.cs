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


    // Start is called before the first frame update
    void Start()
    {
        setColors();
        generateSequence();
        generateColors();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (next == cubes.Length)
        {
            generateSequence();
            generateColors();
            buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            next = 0;
        }
        /*if (next == 0 && buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().IsTrigger())
        {
            buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
        }*/
        if (buttons[sequence[next]].GetComponentInChildren<TriggerButtonSript>().IsTrigger())
        {
            slider.value += 0.1f;
            cubes[next].GetComponent<Image>().color = Color.clear;
            if (next > 0)
            {
                buttons[sequence[next - 1]].GetComponentInChildren<TriggerButtonSript>().reset();
            }
            next++;

        }

    }


    private IEnumerator wait()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            slider.value -= 0.01f;
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

    // TODO !
    private void generateSequence()
    {
        sequence[0] = 0;
        sequence[1] = 1;
        sequence[2] = 2;
    }
    private void generateColors()
    {
        Debug.Log(cubes.Length);
        for (int i = 0; i < cubes.Length; i++)
        {
            int x = (UnityEngine.Random.Range(0, colors.Length) + i) % colors.Length;
            cubes[i].GetComponent<Image>().color = colors[x];
            // eigtl. Button_Tile_Flat
            buttons[sequence[i]].transform.Find("Button_Outer_Ring").gameObject.GetComponent<Renderer>().material.SetColor("_Color", colors[x]);

        }

    }
}
