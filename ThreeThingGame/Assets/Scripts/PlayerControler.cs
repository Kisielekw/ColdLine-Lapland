using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControler : MonoBehaviour
{
    public float Speed;

    private Transform trans;

    private Vector2 playerMovementDirection;

    // Start is called before the first frame update
    void Start()
    {
        trans = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the key inputs for the movement and sets the direction
        if (Input.GetKey(KeyCode.W))
        {
            playerMovementDirection.y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerMovementDirection.y = -1;
        }
        else
        {
            playerMovementDirection.y = 0;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovementDirection.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerMovementDirection.x = -1;
        }
        else
        {
            playerMovementDirection.x = 0;
        }

        //Normalises the value
        playerMovementDirection.Normalize();
    }

    void FixedUpdate()
    {
        //Moves the player
        trans.position = trans.position + new Vector3(playerMovementDirection.x * Speed, playerMovementDirection.y * Speed, 0);
    }
}
