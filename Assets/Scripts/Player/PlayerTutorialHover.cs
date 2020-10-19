using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTutorialHover : MonoBehaviour
{
    private bool movingUp = true;
    private float pingPongModifier = 0.1f;

    private AudioSource sfx;

    private Text dialogue;
    public string[] sentences;

    private float introDelay = 3f;
    private float dialoguePacing = 0.075f;

    private void Start()
    {
        dialogue = GameObject.Find("PlayerDialogue").GetComponent<Text>();
        sfx = gameObject.GetComponent<AudioSource>();
        gameObject.GetComponent<PlayerHandler>().setInSlipgate(true);
        StartCoroutine(talk());
    }
    // Update is called once per frame
    void Update()
    {
        hover();
    }

    private void hover()
    {
        if (gameObject.transform.position.y < 0.65f && movingUp)
        {
            gameObject.transform.position += new Vector3(0, (pingPongModifier * Time.deltaTime), 0);

            if (gameObject.transform.position.y >= 0.65f)
            {
                movingUp = false;
            }
        }
        else if (gameObject.transform.position.y > 0.4 && !movingUp)
        {
            gameObject.transform.position -= new Vector3(0, (pingPongModifier * Time.deltaTime), 0);

            if (gameObject.transform.position.y <= 0.4)
            {
                movingUp = true;
            }
        }
    }

    IEnumerator talk()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            yield return new WaitForSeconds(introDelay);
            dialogue.text = "";

            foreach (char c in sentences[i].ToCharArray())
            {
                dialogue.text += c;

                sfx.pitch = Random.Range(2.0f, 2.15f);
                sfx.Play();

                yield return new WaitForSeconds(dialoguePacing);
            }
        }
        yield return new WaitForSeconds(introDelay);
        dialogue.text = "";
        GameObject.Find("Slipgate").GetComponent<TutorialSlipgate>().activate();
    }
}
