﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
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
            if (player.GetComponent<PlayerHandler>().getFinishedLevelStart())
            {
                gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            }
        }
    }
}
