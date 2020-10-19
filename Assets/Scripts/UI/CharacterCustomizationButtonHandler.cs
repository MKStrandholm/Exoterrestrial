using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCustomizationButtonHandler : MonoBehaviour
{
    PlayerHandler player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
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
        SceneManager.LoadScene(1);
    }    
}
