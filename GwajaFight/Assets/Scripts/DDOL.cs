using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("begin");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DND");

        if (objs.Length > 1)
        {
            Debug.Log("oh shoot");
            Destroy(objs[0]);
        }

        Debug.Log("this");
        DontDestroyOnLoad(this);
    }
}
