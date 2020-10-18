using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyController : MonoBehaviour
{
    bool keyOne = false;
    bool keyTwo = false;
    bool keyThree = false;
    bool keyFour = false;
    bool activated = false;

    Color green = new Color(0.2470f, 1, 0);

    GameObject[] spikes = new GameObject[3];

    private void Start()
    {
        spikes[0] = GameObject.Find("FinalStalagmite1");
        spikes[1] = GameObject.Find("FinalStalagmite2");
        spikes[2] = GameObject.Find("FinalStalagmite3");
    }

    private void Update()
    {
        if (!activated && keyOne && keyTwo && keyThree && keyFour)
        {
            gameObject.GetComponent<SpriteRenderer>().color = green;
            foreach (GameObject spike in spikes)
            {
                spike.SetActive(false);
            }
            activated = true;
        }
    }

    public void activateKeyOne()
    {
        keyOne = true;
    }
    public void activateKeyTwo()
    {
        keyTwo = true;
    }
    public void activateKeyThree()
    {
        keyThree = true;
    }
    public void activateKeyFour()
    {
        keyFour = true;
    }
    public void deactivateKeyOne()
    {
        keyOne = false;
    }
    public void deactivateKeyTwo()
    {
        keyTwo = false;
    }
    public void deactivateKeyThree()
    {
        keyThree = false;
    }
    public void deactivateKeyFour()
    {
        keyFour = false;
    }
}
