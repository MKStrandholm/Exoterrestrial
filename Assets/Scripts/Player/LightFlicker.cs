using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LightFlicker : MonoBehaviour
{
    Light2D light;
    float flickerSpeed = 0.2f;
    bool incrementing = false;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
        {
            if (light.intensity > 0.07f && !incrementing)
            {
                decrementLight();

                if (light.intensity <= 0.07f)
                {
                    incrementing = true;
                }
            }
            else if (light.intensity < 0.09f && incrementing)
            {
                incrementLight();

                if (light.intensity >= 0.09f)
                {
                    incrementing = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            if (light.intensity > 0.40f && !incrementing)
            {
                decrementLight();

                if (light.intensity <= 0.40f)
                {
                    incrementing = true;
                }
            }
            else if (light.intensity < 0.48f && incrementing)
            {
                incrementLight();

                if (light.intensity >= 0.48f)
                {
                    incrementing = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(4))
        {
            if (light.intensity > 0.04f && !incrementing)
            {
                decrementLight();

                if (light.intensity <= 0.04f)
                {
                    incrementing = true;
                }
            }
            else if (light.intensity < 0.07f && incrementing)
            {
                incrementLight();

                if (light.intensity >= 0.07f)
                {
                    incrementing = false;
                }
            }
        }
    }

    void decrementLight()
    {
        light.intensity -=  flickerSpeed * Time.deltaTime;
    }
    void incrementLight()
    {
        light.intensity += flickerSpeed * Time.deltaTime;
    }
}
