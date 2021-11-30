using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBall : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;

    float SEflag = 200;
    float SEsec;
    float x, z;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        Debug.Log("flagon");

        
    }
    void Update()
    {

        SEsec++;

        z = Input.GetAxisRaw("Horizontal");
        x = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("joystick button 7"))
        {
            audioSource.Stop();
        }

       
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if (x != 0 || z != 0 && SEflag == SEsec)
            {
                Debug.Log("音がなった");
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);

                SEflag += 480;
            }


            if (x == 0 || z == 0)
            {
                SEflag = 0;
                SEflag++;
                if (SEflag == 100)
                {
                    audioSource.Stop();
                }
            }
        }

    }
}
