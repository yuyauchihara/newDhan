using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilt : MonoBehaviour
{
    public float adRotate;
    int Frame = 1;
    float zRotate = 0;
    float xRotate = 0;
    float x, z;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(adRotate);
        //Debug.Log(xRotate+","+zRotate);
        //Debug.Log(Frame);
        Debug.Log(Frame);
        neutral();
        floorMove();
    }

    void floorMove()
    {
        z = Input.GetAxisRaw("Horizontal");
        x = Input.GetAxisRaw("Vertical");

        if (x == 1)
        {
            xRotate = Mathf.Clamp(xRotate + adRotate/* * Time.deltaTime*/, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }

        if (x == -1)
        {
            xRotate = Mathf.Clamp(xRotate - adRotate/* * Time.deltaTime*/, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z == 1)
        {
            zRotate = Mathf.Clamp(zRotate - adRotate/* * Time.deltaTime*/, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }

        if (z == -1)
        {
            zRotate = Mathf.Clamp(zRotate + adRotate/* * Time.deltaTime*/, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }

        if (x <= 1 && 0.5 <= x)
        {
            xRotate = Mathf.Clamp(xRotate + adRotate * Time.deltaTime, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (x >= -1 && -0.5 >= x)
        {
            xRotate = Mathf.Clamp(xRotate - adRotate * Time.deltaTime, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z <= 1 && 0.5 <= z)
        {
            zRotate = Mathf.Clamp(zRotate - adRotate * Time.deltaTime, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z >= -1 && -0.5 >= z)
        {
            zRotate = Mathf.Clamp(zRotate + adRotate * Time.deltaTime, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
    }

    void neutral()
    {
        if (x == 0 && z == 0)
        {
            if (zRotate != 0 && zRotate > 0)
            {
                zRotate -= Time.deltaTime * 100;
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (zRotate != 0 && zRotate < 0)
            {
                zRotate += Time.deltaTime * 100;
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (xRotate != 0 && xRotate > 0)
            {
                xRotate -= Time.deltaTime * 100;
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (xRotate != 0 && xRotate < 0)
            {
                xRotate += Time.deltaTime * 100;
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }
        }
    }
}