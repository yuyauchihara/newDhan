using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBall : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    int SEflag;
    float SEsec;
    float x, z;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        //Debug.Log("flagon");

        SEflag = 1;


    }
    void Update()
    {
        

        z = Input.GetAxisRaw("Horizontal");
        x = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("joystick button 7"))
        {
            audioSource.Stop();
        }

        if (x != 0 || z != 0 && SEflag == 1)
        {
            SEflag = 0;
            Debug.Log("音がなった");
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
        }

        if (x == 0 || z == 0)
        {
            SEsec += Time.deltaTime;
            Debug.Log("ニュートラル");
            if (SEsec >= 2 && SEflag == 0)
            {
                Debug.Log("音停止");
                audioSource.Stop();
                SEsec = 0;

            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ball")
    //    {
    //        Debug.Log("true");
    //        if (x != 0 || z != 0 && SEflag == 1)
    //        {
    //            SEflag = 0;
    //            if (SEflag == 0)
    //            {
    //                Debug.Log("noflag");
    //            }
    //            //音(sound1)を鳴らす
    //            audioSource.PlayOneShot(sound1);
    //            Debug.Log("音がなった");
                
    //        }
            
    //    }

    //}
}
