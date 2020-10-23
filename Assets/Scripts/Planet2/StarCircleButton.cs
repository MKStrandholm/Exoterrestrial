using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class StarCircleButton : MonoBehaviour
{
    bool activated = false;
    bool readyToChange = false;
    bool rotateNow = false;

    Light2D light;
    bool incrementing = true;
    float lightPulseSpeed = 200f;

    float rotationAmount = 0;
    float rotationSpeed = 2000f;

    Color activatedColor = new Color(0.2352f, 1f, 0f);
    Color defaultColor = new Color(1f, 0.0705f, 0f);

    public Transform destination;

    private GameObject player;
    bool playerFound = false;

    private GameObject particle;
    bool particleFound = false;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light2D>();
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if (readyToChange)
       {
            if (light.intensity >= 14f && incrementing)
            {
                light.intensity += lightPulseSpeed * Time.deltaTime;

                if (light.intensity >= 50f)
                {
                    incrementing = false;
                }
            }
            else if (light.intensity > 14f && !incrementing)
            {
                light.intensity -= (lightPulseSpeed * 0.25f) * Time.deltaTime;

                if (light.intensity <= 14f)
                {
                    readyToChange = false;
                }
            }
       }

       if (rotateNow)
       {
            particle.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            rotationAmount += (rotationSpeed * Time.deltaTime);

            if (rotationAmount > 2880)
            {
                rotateNow = false;
                rotationAmount = 0;
            }
       }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!playerFound)
            {
                player = collision.gameObject;
            }

            audio.Play();

            readyToChange = true;

            if (!activated)
            {
                StartCoroutine(teleportSuccessful());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(teleporterDelay());
        }
    }

    private void Reset()
    {
        gameObject.GetComponent<SpriteRenderer>().color = defaultColor;
        light.color = defaultColor;
        activated = false;
        readyToChange = false;
    }

    IEnumerator teleporterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Reset();
    }

    IEnumerator teleportSuccessful()
    {
        if (!particleFound)
        {
            particle = gameObject.GetComponentInChildren<ParticleSystem>().gameObject;
            particleFound = true;
        }

        gameObject.GetComponent<SpriteRenderer>().color = activatedColor;
        light.color = activatedColor;
        activated = true;
        particle.transform.position = transform.position;
        particle.GetComponent<ParticleSystem>().Play();
        rotateNow = true;
        yield return new WaitForSeconds(0.5f);
        particle.transform.position = destination.position;
        player.transform.position = destination.position;
        particle.GetComponent<ParticleSystem>().Play();
        rotateNow = true;
    }
}
