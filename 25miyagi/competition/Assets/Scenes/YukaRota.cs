using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YukaRota : MonoBehaviour
{
    void Update()
    {
        Vector3 inputKey = new Vector3();

        //key as Rotation
        inputKey.z = -Input.GetAxis("Horizontal");
        inputKey.x = Input.GetAxis("Vertical");
        this.transform.Rotate(inputKey);
    }
}

