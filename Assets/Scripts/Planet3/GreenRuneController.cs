using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRuneController : MonoBehaviour
{
    bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!activated && collision.gameObject.GetComponent<PlayerHandler>().getHasGreenGem())
            {
                Color c = new Color(0, 1, 0, 1);
                GetComponent<SpriteRenderer>().color = c;
                activated = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public bool getActivated()
    {
        return activated;
    }
}
