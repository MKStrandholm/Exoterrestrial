using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        StartCoroutine(buttonPress());
    }

    IEnumerator buttonPress()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("CharacterSelect");
    }
}
