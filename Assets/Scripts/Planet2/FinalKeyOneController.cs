using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyOneController : MonoBehaviour
{
    Color green = new Color(0.2470f, 1, 0);
    Color red = new Color(1, 0.070f, 0);
    FinalKeyController fkc;

    private void Start()
    {
        fkc = GameObject.Find("ActualKey").GetComponent<FinalKeyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().color = green;
            fkc.activateKeyOne();
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
        fkc.deactivateKeyOne();
    }
}
