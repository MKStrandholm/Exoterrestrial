using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCustomizationButtonHandler : MonoBehaviour
{
    PlayerHandler player;
    GameObject panel;
    float alpha = 0f;
    float fadeModifier = 0.75f;
    bool readyToFade = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHandler>();
        panel = GameObject.Find("Panel");
        panel.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (panel.GetComponent<Image>().color.a >= 1)
        {
            readyToFade = false;
            StartCoroutine(delay());
        }
        else
        {
            if (readyToFade)
            {
                alpha += (Time.deltaTime * fadeModifier);
                Color c = new Color(0, 0, 0, alpha);
                panel.GetComponent<Image>().color = c;
            }            
        }
    }

    public void Next()
    {
        gameObject.GetComponent<AudioSource>().Play();

        if (player.getChoice() == player.getNumberOfChoices() - 1)
        {
            player.setChoice(0);
            player.gameObject.GetComponent<Animator>().SetBool("changed", true);
            updateCharacter();
        }
        else
        {
            player.setChoice(player.getChoice() + 1);
            player.gameObject.GetComponent<Animator>().SetBool("changed", true);
            updateCharacter();
        }


    }

    public void Back()
    {
        gameObject.GetComponent<AudioSource>().Play();

        if (player.getChoice() == 0)
        {
            player.setChoice(player.getNumberOfChoices() - 1);
            player.gameObject.GetComponent<Animator>().SetBool("changed", true);
            updateCharacter();
        }
        else
        {
            player.setChoice(player.getChoice() - 1);
            player.gameObject.GetComponent<Animator>().SetBool("changed", true);
            updateCharacter();
        }
    }

    void updateCharacter()
    {
        player.gameObject.GetComponent<Animator>().SetInteger("choice", player.getChoice());
        StartCoroutine(charSwitchDelay());
    }

    IEnumerator charSwitchDelay()
    {
        yield return new WaitForSeconds(0.0005f);
        player.gameObject.GetComponent<Animator>().SetBool("changed", false);
    }

    public void Submit()
    {
        panel.GetComponent<Image>().enabled = true;
        readyToFade = true;
        StartCoroutine(buttonPress());
    }  

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Tutorial");
    }
    IEnumerator buttonPress()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
    }
}
