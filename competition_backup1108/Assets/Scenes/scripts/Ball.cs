using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject particleObject;
    GameObject parclon;
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            parclon = Instantiate(particleObject, this.transform.position, Quaternion.identity);
            Destroy(parclon, 1.0f);
        }
    }
}