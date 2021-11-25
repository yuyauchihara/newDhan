using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public Text countDownText;
    [SerializeField] GameObject panel;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    private void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine("CountDown");

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

        //音(sound1)を鳴らす
        audioSource.PlayOneShot(sound1);
    }

    IEnumerator CountDown()
    {
        for (int i = 2; i >= 0; i--)
        {
            yield return new WaitForSecondsRealtime(1);
            countDownText.text = i.ToString();
            if (i == 0)
            {
                countDownText.text = "スタート".ToString();
                //音(sound2)を鳴らす
                audioSource.PlayOneShot(sound2);
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}