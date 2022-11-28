using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public AudioClip gong;
    float time = 4f;

    // Start is called before the first frame update
    void Start()
    {
        time += Time.time;
        GetComponent<AudioSource>().PlayOneShot(gong);
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= Time.time)
        {
            Application.LoadLevel(0);
        }
    }
}
