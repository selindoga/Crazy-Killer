using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform ObjectToLook;
    void Update()
    {
        transform.LookAt(ObjectToLook);
    }
}
