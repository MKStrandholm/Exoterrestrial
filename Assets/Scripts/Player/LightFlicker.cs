using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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
        if (light.intensity > 0.07 && !incrementing) 
        {
            decrementLight();

            if (light.intensity <= 0.07)
            {
                incrementing = true;
            }
        }
        else if (light.intensity < 0.09 && incrementing)
        {
            incrementLight();

            if (light.intensity >= 0.09)
            {
                incrementing = false;
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
