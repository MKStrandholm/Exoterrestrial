using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneTimeMusicChanger : MonoBehaviour
{
    AudioSource audioManager;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("Music").GetComponent<AudioSource>();
        audioManager.Stop();

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu"))
        {
            audioManager.clip = clip;
            audioManager.gameObject.GetComponent<MusicHandler>().setCurrentScene(0);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Tutorial"))
        {
            audioManager.clip = clip;
            audioManager.gameObject.GetComponent<MusicHandler>().setCurrentScene(2);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelOne"))
        {
            audioManager.clip = clip;
            audioManager.gameObject.GetComponent<MusicHandler>().setCurrentScene(3);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelTwo"))
        {
            audioManager.clip = clip;
            audioManager.gameObject.GetComponent<MusicHandler>().setCurrentScene(4);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelThree"))
        {
            audioManager.clip = clip;
            audioManager.gameObject.GetComponent<MusicHandler>().setCurrentScene(5);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            audioManager.clip = clip;
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Loading"))
        {
            audioManager.clip = clip;
        }

        audioManager.Play();
        Destroy(gameObject);
    }
}
