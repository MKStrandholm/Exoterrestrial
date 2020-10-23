using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHandler>().setHasGreenGem(true);
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
