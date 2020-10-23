using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSlipgate : MonoBehaviour
{
    bool ready = false;

    GameObject player;
    float alpha = 1f;
    float fadeModifier = 0.5f;

    public AudioClip open;
    public AudioClip close;
    bool shouldPlayOpenSound = true;
    bool shouldPlayCloseSound = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            if (shouldPlayOpenSound)
            {
                gameObject.GetComponent<AudioSource>().clip = open;
                gameObject.GetComponent<AudioSource>().Play();
                shouldPlayOpenSound = false;
            }
            gameObject.GetComponent<Animator>().SetBool("opening", true);

            if (player.GetComponent<SpriteRenderer>().color.a > 0)
            {
                alpha -= (Time.deltaTime * fadeModifier);
                Color c = new Color(1, 1, 1, alpha);
                player.GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("closing", true);
                if (shouldPlayCloseSound)
                {
                    gameObject.GetComponent<AudioSource>().clip = close;
                    gameObject.GetComponent<AudioSource>().Play();
                    shouldPlayCloseSound = false;
                }
            }
        }
    }

    public void activate()
    {
        ready = true;
    }

    public void Finished()
    {
        StartCoroutine(levelDelay());
    }

    IEnumerator levelDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(6);
    }
}
