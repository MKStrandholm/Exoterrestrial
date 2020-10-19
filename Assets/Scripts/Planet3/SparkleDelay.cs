using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleDelay : MonoBehaviour
{
    bool readyToSparkle = false;
    float timer = 0f;
    float random;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(3f, 13f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= random)
        {
            readyToSparkle = true;
        }

        if (readyToSparkle)
        {
            StartCoroutine(sparkle());
        }
    }

    IEnumerator sparkle()
    {
        GetComponent<ParticleSystem>().Play();
        readyToSparkle = false;
        timer = 0;
        random = Random.Range(3f, 13f);
        yield return new WaitForSeconds(0.01f);
    }
}
