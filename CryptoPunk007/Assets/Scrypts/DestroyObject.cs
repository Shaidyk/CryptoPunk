using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject obj;

    void DestroyObj()
    {
        if (obj != null)
            Debug.Log(obj.name);
            Destroy(obj);
    }
}
