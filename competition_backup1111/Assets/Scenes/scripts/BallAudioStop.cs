using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudioStop : MonoBehaviour
{
    int cnt = 0;
    public GameObject flr;
    public GameObject PauseUI;
    AudioSource flrball;

    // Start is called before the first frame update
    void Start()
    {
        flrball = flr.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == 12)
        {
            flrball.enabled = false;
            PauseUI.GetComponent<MenuUI>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coin")
        {
            cnt++;
        }
    }
}