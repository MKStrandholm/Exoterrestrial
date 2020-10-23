using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;


public class SlipgateFinalLevel : MonoBehaviour
{
    GameObject player;
    Animator lightAnim;
    bool playerFound = false;
    bool shouldLerp = false;
    float alpha = 1;
    float fadeModifier = 0.5f;

    AudioSource audio;
    bool shouldPlayCloseSound = true;
    [SerializeField]
    bool powered = false;

    public RedRuneController rrc;
    public GreenRuneController grc;
    public BlueRuneController brc;

    // Start is called before the first frame update
    void Start()
    {   
        lightAnim = GameObject.Find("SlipgateLight").GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (rrc.getActivated() && grc.getActivated() && brc.getActivated())
        {
            powered = true;
        }

        if (powered)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            gameObject.GetComponentInChildren<Light2D>().enabled = true;
        }
        if (!playerFound)
        {
            if (player == null)
            {
                try
                {
                    player = GameObject.FindGameObjectWithTag("Player");
                }
                catch (Exception e)
                {
                    Debug.Log($"Couldn't find player {e.Message}");
                }

            }
            else
            {
                playerFound = true;
            }
        }

        if (shouldLerp)
        {
            if (player.GetComponent<SpriteRenderer>().color.a > 0)
            {
                alpha -= (Time.deltaTime * fadeModifier);
                Color c = new Color(1, 1, 1, alpha);
                player.GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("opening", false);
                gameObject.GetComponent<Animator>().SetBool("closing", true);
                lightAnim.SetBool("closing", true);
                if (shouldPlayCloseSound)
                {
                    audio.Play();
                    shouldPlayCloseSound = false;
                }
            }

            if (player.GetComponentInChildren<Light2D>().intensity > 0)
            {
                player.GetComponentInChildren<Light2D>().intensity -= Time.deltaTime * fadeModifier;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (powered)
        {
            if (collision.gameObject == player)
            {
                Destroy(GameObject.Find("SlipgateR"));
                Destroy(GameObject.Find("SlipgateL"));
                Destroy(GameObject.Find("SlipgateT"));
                player.GetComponent<PlayerHandler>().stopPlayer();
                shouldLerp = true;
            }
        }
       
    }

    public void Finished()
    {
        SceneManager.LoadScene(6);
    }
}
