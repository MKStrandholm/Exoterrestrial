using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyFourController : MonoBehaviour
{
    GameObject keyOne;
    GameObject keyTwo;
    GameObject keyThree;
    Color green = new Color(0.2470f, 1, 0);
    Color red = new Color(1, 0.070f, 0);
    FinalKeyController fkc;

    private void Start()
    {
        keyOne = GameObject.Find("FinalKey1");
        keyTwo = GameObject.Find("FinalKey2");
        keyThree = GameObject.Find("FinalKey3");
        fkc = GameObject.Find("ActualKey").GetComponent<FinalKeyController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (keyOne.GetComponent<FinalKeyOneController>().getActive() == true &&
                keyTwo.GetComponent<FinalKeyTwoController>().getActive() == true &&
                keyThree.GetComponent<FinalKeyThreeController>().getActive() == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = green;
                fkc.activateKeyFour();
                
            }
            else
            {
                keyOne.GetComponent<FinalKeyOneController>().Reset();
                keyTwo.GetComponent<FinalKeyTwoController>().Reset();
                keyThree.GetComponent<FinalKeyThreeController>().Reset();
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
        fkc.deactivateKeyFour();
    }
}
