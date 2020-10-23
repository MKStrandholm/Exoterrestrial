using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenuHover : MonoBehaviour
{
    private bool movingUp = true;
    private float pingPongModifier = 0.1f;
    private float top;
    private float bottom;

    // Start is called before the first frame update
    void Start()
    {
        bottom = gameObject.transform.position.y - 0.15f;
        top = gameObject.transform.position.y + 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < top && movingUp)
        {
            gameObject.transform.position += new Vector3(0, (pingPongModifier * Time.deltaTime), 0);

            if (gameObject.transform.position.y >= top)
            {
                movingUp = false;
            }
        }
        else if (gameObject.transform.position.y > bottom && !movingUp)
        {
            gameObject.transform.position -= new Vector3(0, (pingPongModifier * Time.deltaTime), 0);

            if (gameObject.transform.position.y <= bottom)
            {
                movingUp = true;
            }
        }
    }
}
