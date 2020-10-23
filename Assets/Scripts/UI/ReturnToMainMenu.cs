using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void returnToMainMenu()
    {
        StartCoroutine(buttonPress());
    }

    IEnumerator buttonPress()
    {
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.25f);
        GameObject.Find("Music").GetComponent<MusicHandler>().setCurrentScene(0);
        SceneManager.LoadScene(0);
    }
}
