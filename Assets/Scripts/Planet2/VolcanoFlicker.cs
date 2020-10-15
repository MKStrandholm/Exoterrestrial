using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class VolcanoFlicker : MonoBehaviour
{
    private Light2D light;
    bool incrementing = false;
    public float flickerSpeed = 0.02f;
    float intensity;

    // Start is called before the first frame update
    void Start()
    {
        intensity = Random.Range(9.96f, 15f);
        light = GetComponent<Light2D>();
        intensity = Random.Range(9.96f, 15f);
        light.intensity = intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (light.intensity > 9.95f && !incrementing)
        {
            light.intensity -= flickerSpeed * Time.deltaTime;

            if (light.intensity <= 9.95f)
            {
                incrementing = true;
            }
        }
        else if (light.intensity < 15.1f && incrementing)
        {
            light.intensity += flickerSpeed * Time.deltaTime;

            if (light.intensity >= 15.1f)
            {
                incrementing = false;
            }
        }
    }
}
