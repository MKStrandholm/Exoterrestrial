using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyThreeController : MonoBehaviour
{
    GameObject keyOne;
    GameObject keyTwo;
    Color green = new Color(0.2470f, 1, 0);
    Color red = new Color(1, 0.070f, 0);
    FinalKeyController fkc;
    AudioSource audio;

    private void Start()
    {
        keyOne = GameObject.Find("FinalKey1");
        keyTwo = GameObject.Find("FinalKey2");
        fkc = GameObject.Find("ActualKey").GetComponent<FinalKeyController>();
        audio = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (keyOne.GetComponent<FinalKeyOneController>().getActive() == true &&
                keyTwo.GetComponent<FinalKeyTwoController>().getActive() == true && getActive() == false)
            {
                gameObject.GetComponent<SpriteRenderer>().color = green;
                fkc.activateKeyThree();
                audio.Play();
            }
            else if (keyOne.GetComponent<FinalKeyOneController>().getActive() == false ||
                    keyTwo.GetComponent<FinalKeyTwoController>().getActive() == false)
            {
                keyOne.GetComponent<FinalKeyOneController>().Reset();
                keyTwo.GetComponent<FinalKeyTwoController>().Reset();
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
        fkc.deactivateKeyThree();
    }
}
