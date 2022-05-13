
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour
{
    public Image[] healthHearts;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 4:
                foreach (Image img in healthHearts) {
                    img.GetComponent<RectTransform>().sizeDelta = new Vector2(39, 37);
                    img.gameObject.SetActive(true);
                    img.GetComponent<Animator>().enabled = false;
                }
                healthHearts[3].GetComponent<Animator>().enabled = true;

                /*healthHearts[0].gameObject.SetActive(true);
                healthHearts[1].gameObject.SetActive(true);
                healthHearts[2].gameObject.SetActive(true);
                healthHearts[3].gameObject.SetActive(true);
                healthHearts[0].GetComponent<Animator>().enabled = false;
                healthHearts[1].GetComponent<Animator>().enabled = false;
                healthHearts[2].GetComponent<Animator>().enabled = false;
                healthHearts[3].GetComponent<Animator>().enabled = true;*/

                break;

            case 3:
                healthHearts[0].gameObject.SetActive(true);
                healthHearts[1].gameObject.SetActive(true);
                healthHearts[2].gameObject.SetActive(true);
                healthHearts[3].gameObject.SetActive(false);
                healthHearts[0].GetComponent<Animator>().enabled = false;
                healthHearts[1].GetComponent<Animator>().enabled = false;
                healthHearts[2].GetComponent<Animator>().enabled = true;
                break;

            case 2:
                healthHearts[0].gameObject.SetActive(true);
                healthHearts[1].gameObject.SetActive(true);
                healthHearts[2].gameObject.SetActive(false);
                healthHearts[3].gameObject.SetActive(false);
                healthHearts[0].GetComponent<Animator>().enabled = false;
                healthHearts[1].GetComponent<Animator>().enabled = true;

                break;

            case 1:
                healthHearts[0].gameObject.SetActive(true);
                healthHearts[1].gameObject.SetActive(false);
                healthHearts[2].gameObject.SetActive(false);
                healthHearts[3].gameObject.SetActive(false);
                healthHearts[0].GetComponent<Animator>().enabled = true;
                break;

            case 0:
                foreach (Image img in healthHearts)
                {
                    img.gameObject.SetActive(false);
                }
                break;

            default:
                break;
        }

    }
}
