using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caroller : MonoBehaviour
{
    public GameObject Bullet;
    public Vector2 Velocity;

    private int health = 1;
    private bool attack = false;
    private float nextShot;
    private Vector2 aimVector;

    private Transform trans;
    private Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nextShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }

        //TODO AI

        

        aimVector = playerTrans.position - trans.position;

        if(aimVector.magnitude < 4.5f)
        {
            aimVector = new Vector2(aimVector.x + Random.Range(-1, 1), aimVector.y + Random.Range(-1, 1));
            aimVector.Normalize();
            if(Time.time >= nextShot)
            {
                GameObject shot = GameObject.Instantiate(Bullet);
                nextShot = Time.time + 1;

                Transform shotTrans = shot.GetComponent<Transform>();
                Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();

                shotTrans.position = trans.position + new Vector3(aimVector.x * 0.75f, aimVector.y * 0.75f, 0);
                shotRB.velocity = aimVector * 20;

                GameObject.Destroy(shot, 2);
            }
        }
    }

    private void FixedUpdate()
    {
        if(aimVector.magnitude > 4.5f)
        {
            aimVector.Normalize();
            Velocity = aimVector * 0.1f;
            Debug.Log(Velocity);
            trans.position = trans.position + new Vector3(aimVector.x * 0.05f, aimVector.y * 0.05f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Bullets")
        {
            health--;
        }
    }
}
