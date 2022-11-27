using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void testSceneChange(int num)
    {
        Debug.Log("Change");
        Application.LoadLevel(num);
    }
}
