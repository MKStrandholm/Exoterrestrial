using UnityEngine;

public class IceSlipperyController : MonoBehaviour
{
    private float iceSpeed = 7.5f;
    bool onIce = false;

    [SerializeField]
    GameObject player;
    PlayerHandler ph;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

        }
        else
        {
            ph = player.GetComponent<PlayerHandler>();

            if (onIce && !ph.getAllowMovement())
            {
                    // move player
                    // up
                    if (ph.getDirection() == 1)
                    {
                        moveUp();
                    }
                    // down
                    else if (ph.getDirection() == 2)
                    {
                        moveDown();
                    }
                    // left
                    else if (ph.getDirection() == 3)
                    {
                        moveLeft();
                    }
                    // right
                    else
                    {
                        moveRight();
                    }
                }   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If player has stepped on ice
       if (collision.gameObject.tag == "Player")
        {
            onIce = true;
            ph.setAllowMovement(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onIce = false;
            ph.setAllowMovement(true);
        }
    }

    private void moveUp()
    {
            ph.gameObject.transform.position += new Vector3(0, Time.deltaTime * iceSpeed, 0);
    }
    private void moveDown()
    {
            ph.gameObject.transform.position -= new Vector3(0, Time.deltaTime * iceSpeed, 0);


    }
    private void moveLeft()
    {
            ph.gameObject.transform.position -= new Vector3(Time.deltaTime * iceSpeed, 0, 0);

    }
    private void moveRight()
    {
        ph.gameObject.transform.position += new Vector3(Time.deltaTime * iceSpeed, 0, 0);
    }
}
