using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToAndFromBlackPanelController : MonoBehaviour
{
    float alpha = 1f;
    float fadeModifier = 0.75f;
    bool readyToFade = true;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Image>().color.a <= 0)
        {
            readyToFade = false;
            StartCoroutine(delay());
        }
        else
        {
            if (readyToFade)
            {
                alpha -= (Time.deltaTime * fadeModifier);
                Color c = new Color(0, 0, 0, alpha);
                gameObject.GetComponent<Image>().color = c;
            }
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
    }
}
