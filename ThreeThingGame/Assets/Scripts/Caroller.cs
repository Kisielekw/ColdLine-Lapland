using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caroller : MonoBehaviour
{
    public GameObject Bullet;
    public int Health = 1;
    public float ShotInterval = 2;
    public bool isBoss = false;
    public Sprite green;
    
    private float nextShot;
    private Vector2 aimVector;

    private Transform trans;
    private Transform playerTrans;
    private Rigidbody2D RB2D;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        RB2D = GetComponent<Rigidbody2D>();
        nextShot = Time.time;

        if(Random.Range(0,3) == 0 && !isBoss)
        {
            GetComponent<SpriteRenderer>().sprite = green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isBoss && Health == 0)
        {
            Application.LoadLevel(3);
        }

        if(Health == 0)
        {
            Destroy(gameObject);
        }

        aimVector = playerTrans.position - trans.position;

        float angle = Vector2.SignedAngle(Vector2.up, aimVector);
        trans.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((aimVector.magnitude < 4.5f && !isBoss) || (aimVector.magnitude <= 15 && isBoss))
        {
            aimVector = new Vector2(aimVector.x + ((float)Random.Range(-20, 20) / 10f), aimVector.y + ((float)Random.Range(-20, 20) / 10f));
            aimVector.Normalize();
            if(Time.time >= nextShot)
            {
                GameObject shot = GameObject.Instantiate(Bullet);
                nextShot = Time.time + ShotInterval;

                Transform shotTrans = shot.GetComponent<Transform>();
                Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();

                if (!isBoss)
                {
                    shotTrans.position = trans.position + new Vector3(aimVector.x * 0.75f, aimVector.y * 0.75f, 0);
                }
                else
                {
                    shotTrans.position = trans.position + new Vector3(aimVector.x * 1.5f, aimVector.y * 1.5f, 0);
                }
                shotRB.velocity = aimVector * 20;

                GameObject.Destroy(shot, 2);
            }
        }
    }

    private void FixedUpdate()
    {
        if (aimVector.magnitude > 4.5f && aimVector.magnitude < 20 && !isBoss)
        {
            aimVector.Normalize();
            trans.position = trans.position + new Vector3(aimVector.x * 0.05f, aimVector.y * 0.05f, 0);
        }

        RB2D.velocity = Vector2.zero;
        RB2D.angularVelocity = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Bullets")
        {
            Health--;
        }
    }
}
