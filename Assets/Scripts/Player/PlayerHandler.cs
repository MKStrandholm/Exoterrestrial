using System;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    /// <summary>
    /// 
    /// 
    /// variables related to movement
    /// </summary>
    private float speedModifier = 1f;
    private float sprintModifier = 2f;
    private bool isSprinting = false;
    private bool inSlipgate = false;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        movementHandler();
    }

    private void movementHandler()
    {
        if (!inSlipgate)
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float yAxis = Input.GetAxisRaw("Vertical");


            switch (xAxis)
            {
                // Right
                case 1:
                    Vector3 xForward = new Vector3(speedModifier, 0, 0);
                    if (isSprinting)
                    {
                        transform.position += Vector3.ClampMagnitude(xForward, speedModifier) * sprintModifier * Time.deltaTime;
                    }
                    else
                    {
                        transform.position += Vector3.ClampMagnitude(xForward, speedModifier) * Time.deltaTime;
                    }
                    swapDirection(1);
                    anim.SetInteger("direction", 3);
                    anim.SetBool("walking", true);
                    break;
                // Left
                case -1:
                    Vector3 xBackward = new Vector3(speedModifier, 0, 0);
                    if (isSprinting)
                    {
                        transform.position -= Vector3.ClampMagnitude(xBackward, speedModifier) * sprintModifier * Time.deltaTime;
                    }
                    else
                    {
                        transform.position -= Vector3.ClampMagnitude(xBackward, speedModifier) * Time.deltaTime;
                    }
                    swapDirection(-1);
                    anim.SetInteger("direction", 3);
                    anim.SetBool("walking", true);
                    break;
                case 0:
                    if (yAxis == 0)
                    {
                        anim.SetBool("walking", false);
                    }
                    break;
            }

            switch (yAxis)
            {
                // Up
                case 1:
                    Vector3 yForward = new Vector3(0, speedModifier, 0);
                    if (isSprinting)
                    {
                        transform.position += Vector3.ClampMagnitude(yForward, speedModifier) * sprintModifier * Time.deltaTime;
                    }
                    else
                    {
                        transform.position += Vector3.ClampMagnitude(yForward, speedModifier) * Time.deltaTime;
                    }
                    anim.SetInteger("direction", 1);
                    anim.SetBool("walking", true);
                    break;
                // Down
                case -1:
                    Vector3 yBackward = new Vector3(0, speedModifier, 0);
                    if (isSprinting)
                    {
                        transform.position -= Vector3.ClampMagnitude(yBackward, speedModifier) * sprintModifier * Time.deltaTime;
                    }
                    else
                    {
                        transform.position -= Vector3.ClampMagnitude(yBackward, speedModifier) * Time.deltaTime;
                    }
                    anim.SetBool("walking", true);
                    anim.SetInteger("direction", 2);
                    break;
                case 0:
                    if (xAxis == 0)
                    {
                        anim.SetBool("walking", false);
                    }
                    break;
            }

            if (Input.GetButton("Sprint"))
            {
                isSprinting = true;
                anim.SetFloat("modifier", 2);
            }
            else
            {
                isSprinting = false;
                anim.SetFloat("modifier", 1);
            }
        }
    }

    private void swapDirection(float value)
    {
        transform.localScale = new Vector3(value, 1, 1);
    }

    public void stopPlayer()
    {
        speedModifier = 0;
        anim.SetBool("walking", false);
        inSlipgate = true;
    }

    public void setInSlipgate(bool inGate)
    {
        inSlipgate = inGate;
    }
    public bool getInSlipgate()
    {
        return inSlipgate;
    }
}
