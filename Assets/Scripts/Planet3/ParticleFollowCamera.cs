using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollowCamera : MonoBehaviour
{
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(camera.transform.position.x - 15, camera.transform.position.y, camera.transform.position.z + 4f); ;
    }
}
