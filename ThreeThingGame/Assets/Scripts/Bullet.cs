using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip HitSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(HitSound);
        GetComponent<Transform>().position = new Vector3(1000,1000,100);
        Destroy(this.gameObject, 0.5f);
    }
}
