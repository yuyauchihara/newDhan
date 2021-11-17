using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tilt : MonoBehaviour
{
    float adRotate = 0.333333f;
    int Frame = 0;
    float zRotate = 0;
    float xRotate = 0;
    float x, z;
    float acce = 12.6f;
    float time = 0;
    float MoveBackTime = 0;
    float tltTime = 0;
    int NTframe = 0;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(adRotate);
        //Debug.Log(xRotate+","+zRotate);
        Debug.Log(Frame);
        //Debug.Log(NTframe);

        neutral();
        floorMove();
        katamuke();

        if (Input.GetKey(KeyCode.G))
        {
            Frame = 0;
        }

        if (z == 1 && zRotate != -30)
        {
            Frame += 1;
        }

        if (z == -1 && zRotate != 30)
        {
            Frame += 1;
        }

        if (x == 1 && xRotate != 30)
        {
            Frame += 1;
        }

        if (x == -1 && xRotate != -30)
        {
            Frame += 1;
        }

    }

    void floorMove()
    {
        z = Input.GetAxisRaw("Horizontal");
        x = Input.GetAxisRaw("Vertical");

        if (x == 1)
        {
            time += Time.deltaTime;
            xRotate = Mathf.Clamp(xRotate + acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }

        if (x == -1)
        {
            time += Time.deltaTime;
            xRotate = Mathf.Clamp(xRotate - acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z == 1)
        {
            time += Time.deltaTime;
            zRotate = Mathf.Clamp(zRotate - acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }

        if (z == -1)
        {
            time += Time.deltaTime;
            zRotate = Mathf.Clamp(zRotate + acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
    }

    void neutral()
    {
        if (x != 0 || z != 0)
        {
            MoveBackTime = 0;
        }

        if (x == 0 && z == 0)
        {
            time = 0;

            NTframe = Mathf.Clamp(NTframe + 1, 0, 60);

            if (zRotate != 0 && zRotate > 0)
            {
                MoveBackTime += Time.deltaTime;
                zRotate = Mathf.Clamp(zRotate - acce * Time.deltaTime * MoveBackTime, 0, 30);
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (zRotate != 0 && zRotate < 0)
            {
                MoveBackTime += Time.deltaTime;
                zRotate = Mathf.Clamp(zRotate + acce * Time.deltaTime * MoveBackTime, -30, 0);
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (xRotate != 0 && xRotate > 0)
            {
                MoveBackTime += Time.deltaTime;
                xRotate = Mathf.Clamp(xRotate - acce * Time.deltaTime * MoveBackTime, 0, 30);
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }

            if (xRotate != 0 && xRotate < 0)
            {
                MoveBackTime += Time.deltaTime;
                xRotate = Mathf.Clamp(xRotate + acce * Time.deltaTime * MoveBackTime, -30, 0);
                transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
            }
        }
    }

    void katamuke()
    {

        if (x <= 1 && 0.5 <= x) //+
        {
            tltTime += Time.deltaTime;
            xRotate = Mathf.Clamp(xRotate + acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (x >= -1 && -0.5 >= x) //-
        {
            tltTime += Time.deltaTime;
            xRotate = Mathf.Clamp(xRotate - acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z <= 1 && 0.5 <= z) //-
        {
            tltTime += Time.deltaTime;
            zRotate = Mathf.Clamp(zRotate - acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
        if (z >= -1 && -0.5 >= z) //+
        {
            tltTime += Time.deltaTime;
            zRotate = Mathf.Clamp(zRotate + acce * Time.deltaTime * time, -30, 30);
            transform.eulerAngles = new Vector3(xRotate, 0, zRotate);
        }
    }
}