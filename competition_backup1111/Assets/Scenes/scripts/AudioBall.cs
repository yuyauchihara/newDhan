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