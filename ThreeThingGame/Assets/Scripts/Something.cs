using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Something : MonoBehaviour
{
    public GameObject thing;
    public GameObject thi;
    float time = 0;

    bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            active = true;
            time = Time.time + 4;
        }
        if(time <= Time.time && active)
        {
            thi.SetActive(false);
            thing.SetActive(true);
            active = false;
        }
    }
}
