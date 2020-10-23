using UnityEngine;

public class FinalKeyOneController : MonoBehaviour
{
    Color green = new Color(0.2470f, 1, 0);
    Color red = new Color(1, 0.070f, 0);
    FinalKeyController fkc;
    AudioSource audio;

    private void Start()
    {
        fkc = GameObject.Find("ActualKey").GetComponent<FinalKeyController>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && getActive() == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = green;
            fkc.activateKeyOne();
            audio.Play();
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
        fkc.error();
    }
}
