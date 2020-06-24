using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("begin");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DND");

        if (objs.Length > 1)
        {
            Debug.Log("oh shoot");
            Destroy(objs[1]);
        }

        Debug.Log("this");
        DontDestroyOnLoad(this);
    }
}
