using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFloor : MonoBehaviour
{

    public AudioClip sound1;
    private bool stay;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (stay == true)
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
        }

        if(stay == false)
        {
            audioSource.Stop();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //ボールに当たったとき
        if (other.gameObject.tag == "Ball")
        {
            stay = true;
        }
    }
     void OnCollisionExit(Collision other)
    {
        stay = false;
    }
}
