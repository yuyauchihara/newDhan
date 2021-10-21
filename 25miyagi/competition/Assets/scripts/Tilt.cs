using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    Transform Tx, Tz;
    float Ax, Az;
    // Start is called before the first frame update
    void Start()
    {
        Tx = GetComponent<Transform>();
        Tz = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Ax = Tx.localEulerAngles.x; //W,S
        Az = Tz.localEulerAngles.z; //A,D

        Debug.Log(Ax + "," + Az);

        if (Input.GetKey(KeyCode.A))
        {
            //if(Az <= 30f)
            //{
                transform.Rotate(0, 0, 1);
            //}
        }

        if (Input.GetKey(KeyCode.D))
        {
            //if (Az <= 330)
            //{
                transform.Rotate(0, 0, -1);
            //}
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (Ax <= 30f)
            {
                transform.Rotate(1, 0, 0);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Ax >= -30f)
            {
                transform.Rotate(-1, 0, 0);
            }
        }
    }
}
