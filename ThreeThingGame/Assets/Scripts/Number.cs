using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public bool unit;
    public Sprite[] text;
    private GameObject player;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int num = 0;
        int ammo = player.GetComponent<PlayerControler>().Ammo;
        if (unit)
        {
            num = ammo % 10;
        }
        else
        {
            num = ammo / 10;
        }

        image.sprite = text[num];
    }
}
