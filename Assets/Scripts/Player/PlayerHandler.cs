using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{
    private static int playerChoice;
    private int numberOfChoices = 3;
    private float speedModifier = 1.5f;
    private float sprintModifier = 3f;
    private bool isSprinting = false;
    private bool inSlipgate = false;
    private bool finishedLevelStart = false;
    [SerializeField]
    private bool allowMovement = true;


    private Animator anim;
    private int direction;

    [SerializeField]
    private bool colliding = false;

    private bool hasRedGem = false;
    private bool hasGreenGem = false;
    private bool hasBlueGem = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        anim.SetInteger("choice", playerChoice);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementHandler();
    }

    private void movementHandler()
    {

        if (!inSlipgate && allowMovement)
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
                        direction = 4;
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
                        direction = 3;
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
                        direction = 1;
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
                        direction = 2;
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

    public void setChoice(int option)
    {
        playerChoice = option;
    }

    public int getChoice()
    {
        return playerChoice;
    }

    public int getNumberOfChoices()
    {
        return numberOfChoices;
    }

    public int getDirection()
    {
        return direction;
    }

    public void setDirection(int dir)
    {
        direction = dir;
    }

    public bool getFinishedLevelStart()
    {
        return finishedLevelStart;
    }

    public void setFinishedLevelStart(bool finished)
    {
        finishedLevelStart = finished;
    }

    public bool getColliding()
    {
        return colliding;
    }
    public void setColliding(bool col)
    {
        colliding = col;
    }
    public bool getAllowMovement()
    {
        return allowMovement;
    }
    public void setAllowMovement(bool allow)
    {
        allowMovement = allow;
    }
    public void setHasGreenGem(bool has)
    {
        hasGreenGem = has;
    }
    public void setHasBlueGem(bool has)
    {
        hasBlueGem = has;
    }
    public void setHasRedGem(bool has)
    {
        hasRedGem = has;
    }
    public bool getHasGreenGem()
    {
        return hasGreenGem;
    }
    public bool getHasBlueGem()
    {
        return hasBlueGem;
    }
    public bool getHasRedGem()
    {
        return hasRedGem;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NonWalkable")
        {
            colliding = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
    }

}
