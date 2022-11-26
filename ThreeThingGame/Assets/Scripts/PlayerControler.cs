using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControler : MonoBehaviour
{
    public float Speed = 0.1f;
    public float BulletSpeed = 20;
    public GameObject Bullet;
    public int Ammo = 50;
    public int Health = 1;

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

        //Rotation
        Vector2 screenSize = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 mousePos = Input.mousePosition;

        mousePos -= screenSize;

        //Finding the agle of the mouse
        float angle = Vector2.SignedAngle(Vector2.up, mousePos);

        //changing the rotation of character
        trans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //reseting rotation of camera
        GameObject.Find("Main Camera").GetComponent<Transform>().rotation = Quaternion.identity;




        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            GameObject shot = GameObject.Instantiate(Bullet);
            Ammo--;

            Transform shotTrans = shot.GetComponent<Transform>();

            Vector2 translate = mousePos;
            translate.Normalize();
            shotTrans.position = trans.position + new Vector3(translate.x * 0.75f, translate.y * 0.75f, 0);
            shotTrans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Rigidbody2D shotPhys = shot.GetComponent<Rigidbody2D>();
            shotPhys.velocity = translate * BulletSpeed;
            GameObject.Destroy(shot, 2);
        }
    }

    void FixedUpdate()
    {
        //Moves the player
        trans.position = trans.position + new Vector3(playerMovementDirection.x * Speed, playerMovementDirection.y * Speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ammo")
        {
            Ammo += 15;
        }
    }
}
