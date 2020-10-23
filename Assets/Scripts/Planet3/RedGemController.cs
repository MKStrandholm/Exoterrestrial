using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHandler>().setHasRedGem(true);
            GetComponent<AudioSource>().Play();
            StartCoroutine(deathDelay());
        }
    }

    IEnumerator deathDelay()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
