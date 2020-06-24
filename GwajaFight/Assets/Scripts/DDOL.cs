using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD : MonoBehaviour
{
    public void DontDestroy()
    {
        DontDestroyOnLoad(gameObject);
    }
}
