using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SlipgateTrigger : MonoBehaviour
{
    GameObject player;
    Animator lightAnim;
    bool playerFound = false;
    bool shouldLerp = false;
    float alpha = 1;
    float fadeModifier = 0.5f;

    AudioSource audio;
    bool shouldPlayCloseSound = true;

    // Start is called before the first frame update
    void Start()
    {
        lightAnim = GameObject.Find("SlipgateLight").GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
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
                alpha -= (Time.deltaTime*fadeModifier);
                Color c = new Color(1, 1, 1, alpha);
                player.GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
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
                player.GetComponentInChildren<Light2D>().intensity -= Time.deltaTime*fadeModifier;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerHandler>().stopPlayer();
            shouldLerp = true;
        }
    }

    public void Finished()
    {
        SceneManager.LoadScene(6);
    }
}
