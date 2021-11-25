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