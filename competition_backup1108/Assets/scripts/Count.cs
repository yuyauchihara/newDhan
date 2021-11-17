using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Text countDownText;
    [SerializeField] GameObject panel;
    private void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown()
    {
        for (int i = 2; i >= 0; i--)
        {
            yield return new WaitForSecondsRealtime(1);
            countDownText.text = i.ToString();
            if(i == 0)
            {
                countDownText.text = "スターと".ToString();
            }
        }
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
    }
}
