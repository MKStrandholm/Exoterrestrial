using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    int currentScene = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setCurrentScene(int scene)
    {
        currentScene = scene;
    }

    public int getCurrentScene()
    {
        return currentScene;
    }
}
