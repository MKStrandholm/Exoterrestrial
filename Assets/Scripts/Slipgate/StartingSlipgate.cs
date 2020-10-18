using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StartingSlipgate : MonoBehaviour
{
    public GameObject playerReference;
    private GameObject spawnedPlayer;
    public GameObject targetDes;

    Animator anim;
    Animator lightAnim;

    float alpha = 0;
    float fadeModifier = 0.5f;
    bool ready = false;
    float introDisplacementSpeed = 1.0f;

    public Material unlit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("ready", true);
        lightAnim = GameObject.Find("StartingSlipgateLight").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            if (spawnedPlayer.GetComponent<SpriteRenderer>().color.a < 1)
            {
                alpha += (Time.deltaTime * fadeModifier);
                Color c = new Color(1, 1, 1, alpha);
                spawnedPlayer.GetComponent<SpriteRenderer>().color = c;
            }
            else
            {
                spawnedPlayer.GetComponent<Animator>().SetBool("walking", true);
                spawnedPlayer.GetComponent<Animator>().SetFloat("modifier", 1.00f);
                spawnedPlayer.transform.localPosition = Vector2.MoveTowards(spawnedPlayer.transform.localPosition, targetDes.transform.localPosition, Time.deltaTime * introDisplacementSpeed);

                // Done walking
                if (spawnedPlayer.transform.localPosition == targetDes.transform.localPosition)
                {
                    spawnedPlayer.GetComponent<Animator>().SetBool("walking", false);
                    anim.SetBool("canClose", true);
                    lightAnim.SetBool("closing", true);
                }
            }
            
        }
    }

    public void SpawnPlayer()
    {
        Transform tmp = transform;
        tmp.position = new Vector2(tmp.position.x + 0.01f, tmp.position.y);
        spawnedPlayer = Instantiate(playerReference, tmp);

        spawnedPlayer.GetComponent<PlayerHandler>().setInSlipgate(true);
        spawnedPlayer.GetComponent<Animator>().SetInteger("direction", 2);
        spawnedPlayer.GetComponentInChildren<Light2D>().enabled = false;
        ready = true;

    }

    public void Finished()
    {
        ready = false;
        transform.DetachChildren();
        Destroy(GameObject.Find("TargetDes"));

        spawnedPlayer.GetComponent<PlayerHandler>().setInSlipgate(false);
        spawnedPlayer.GetComponentInChildren<Light2D>().enabled = true;
        spawnedPlayer.tag = "Player";
        GameObject cam = GameObject.Find("Main Camera");

        cam.transform.parent = spawnedPlayer.transform;

        Transform camFix = cam.transform;
        camFix.localPosition = new Vector3(0,0,camFix.transform.localPosition.z);
        cam.transform.localPosition = camFix.localPosition;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            spawnedPlayer.GetComponent<SpriteRenderer>().material = unlit;
        }

        Destroy(gameObject);
    }
}
