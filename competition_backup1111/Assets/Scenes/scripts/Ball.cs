using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject particleObject;
    public GameObject damage;
    GameObject parclon;
    Rigidbody rb;
    bool hitCheck = false;
    bool getZahyo = false;
    int Fcunt = 0;


    Vector3 Bpos;
    Vector3 flrPos;
    Vector3 hitBpos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Bpos = gameObject.transform.position;

        if (hitCheck == true)
        {
            Fcunt++;

            if (Fcunt != 91)
            {
                if (getZahyo == false)
                {
                    hitBpos = gameObject.transform.position;
                    getZahyo = true;
                }
                rb.velocity = Vector3.zero;
                //Bpos.x = hitBpos.x;
                //Bpos.z = hitBpos.z;
            }
            else
            {
                hitCheck = false;
                Fcunt = 0;
            }

        }
        gameObject.transform.position = Bpos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            parclon = Instantiate(particleObject, this.transform.position, Quaternion.identity);
            Destroy(parclon, 1.0f);
        }

        if (collision.gameObject.tag == "enemy")
        {
            hitCheck = true;
            parclon = Instantiate(damage, this.transform.position, Quaternion.identity);
            Destroy(parclon, 1.0f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEnemy : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip damage;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {

        //ボールに当たったとき
        if (other.gameObject.tag == "Ball")
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(damage);
        }
    }
}