using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject particleObject;
    GameObject parclon;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            parclon = Instantiate(particleObject, this.transform.position, Quaternion.identity);
            Destroy(parclon, 1.0f);
        }
    }
}