using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite[] sprites;
    public AudioClip[] HitSounds;

    private void Start()
    {
        Sprite chosen = sprites[Random.Range(0, sprites.Length - 1)];
        GetComponent<SpriteRenderer>().sprite = chosen;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(HitSounds.Length > 0)
        { 
            AudioClip chosen = HitSounds[Random.Range(0, HitSounds.Length - 1)];
            GetComponent<AudioSource>().PlayOneShot(chosen);
        }
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(this.gameObject, 0.5f);
    }
}
