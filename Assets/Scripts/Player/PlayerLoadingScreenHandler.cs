using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLoadingScreenHandler : MonoBehaviour
{
    float modifier = 9f;
    GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("Music");
        gameObject.GetComponent<PlayerHandler>().setInSlipgate(true);
        gameObject.GetComponent<Animator>().SetBool("loading", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 15f)
        {
            if (music.GetComponent<MusicHandler>().getCurrentScene() == 5)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                SceneManager.LoadScene(music.GetComponent<MusicHandler>().getCurrentScene() + 1);
            }   
        }
        else
        {
            gameObject.transform.position += new Vector3(Time.deltaTime * modifier, 0, 0);
        }
     
    }
}
