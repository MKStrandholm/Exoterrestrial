using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyTwoController : MonoBehaviour
{
    GameObject keyOne;
    Color green = new Color(0.2470f, 1, 0);
    Color red = new Color(1, 0.070f, 0);
    FinalKeyController fkc;
    AudioSource audio;

    private void Start()
    {
        keyOne = GameObject.Find("FinalKey1");
        fkc = GameObject.Find("ActualKey").GetComponent<FinalKeyController>();
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (keyOne.GetComponent<FinalKeyOneController>().getActive() == true && getActive() == false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = green;
                fkc.activateKeyTwo();
                audio.Play();
            }
        }
    }
    public bool getActive()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color == green)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Reset()
    {
        gameObject.GetComponent<SpriteRenderer>().color = red;
        fkc.deactivateKeyTwo();
    }
}
