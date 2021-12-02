
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Coin : MonoBehaviour
{
    //public GameObject unlockObj;
    public TextMeshProUGUI countText;

    public int count;

    public GameObject particleObject;
    GameObject parclon;

    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject RetryPanel;

    [SerializeField] private GameObject RetryCursor1;
    [SerializeField] private GameObject RetryCursor2;
    [SerializeField] private GameObject RetryCursor3;

    [SerializeField] private GameObject GameClear;

    public GameObject ball;
    public GameObject flr;
    Rigidbody Brb;

    int Clear = 0;
    int hyouji = 0;
    int Resultcount = 0;
    int Retrycount = 0;
    int stop = 0;
    float x;
    float seconds;
    float af = 0, df = 0;

    int kaisucount;

    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    void Start()
    {
        kaisucount = 0; 

        count = 0;
        //countText.text = "0/12" + count.ToString();
        //countText.text = count.ToString() + "/12";
        Score();

        ResultPanel.SetActive(false);
        RetryPanel.SetActive(false);
        RetryCursor1.SetActive(false);
        RetryCursor2.SetActive(false);
        RetryCursor3.SetActive(false);
        GameClear.SetActive(false);
        //StartCoroutine("GameClearcount");

        Brb = ball.GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    void Score()
    {
        countText.text = count.ToString() + "/12";
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //unlockObj.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            count += 1;
            //countText.text =  count.ToString() + "/12";
            Score();
            //if(count == 12)
            //{

            //    hyouji = 1;
            //}

            if (count == 12)
            {
                
                GameClear.SetActive(true);
                stop = 1;
                parclon = Instantiate(particleObject, this.transform.position, Quaternion.identity);

                //ball.SetActive(false);
                //Brb.isKinematic = true;
                //flr.GetComponent<Tilt>().enabled = false;

            }

        }

    }


    void Update()
    {
        if (stop == 1)
        {
            seconds += Time.deltaTime;
            if (seconds >= 2)
            {
                seconds = 0;
                GameClear.SetActive(false);
                Clear = 1;

            }
        }
        if (Clear == 1)
        {
            if (kaisucount ==0) {
                kaisucount = 1;
                Time.timeScale = 0;
                Resultcount = 1;
                ResultPanel.SetActive(true);
            }


            bool Resultkettei = Input.GetKeyDown("joystick button 1");
            if (Resultkettei == true & Resultcount == 1)
            {
                Retrycount = 1;
                ResultPanel.SetActive(false);
                RetryPanel.SetActive(true);

            }
            x = Input.GetAxisRaw("Vertical");

            //カーソルの位置の処理、連続入力の防止ここから

            //スティックが上
            if (x > 0)
            {
                af++;//上入力の間加算し続ける

                if (af == 1)//afが加算され続けている時、その値が1の瞬間のみ以下の処理を行う。故に連続入力の対策となる
                {
                    Retrycount--;

                    //音(sound1)を鳴らす
                    audioSource.PlayOneShot(sound1);
                }
            }
            else
            {
                af = 0;//スティックが離されるか別入力になったら0にする
            }
            //カーソルが１の時に更に上に上げられたらカーソルの位置を３に移動させる
            if (Retrycount <= 0)
            {
                Retrycount = 3;
            }

            //スティックが下
            if (x < 0)
            {
                df++;//下入力の間加算を続ける

                if (df == 1)
                {
                    Retrycount++;

                    //音(sound1)を鳴らす
                    audioSource.PlayOneShot(sound1);
                }
            }
            else
            {
                df = 0;
            }
            if (Retrycount >= 4)
            {
                Retrycount = 1;
            }
            //カーソルの位置の処理、連続入力の防止ここまで


            //カーソルが1
            if (Retrycount == 1)
            {
                RetryCursor1.SetActive(true);
                RetryCursor2.SetActive(false);
                RetryCursor3.SetActive(false);

            }

            //カーソルが２にある時の操作
            else if (Retrycount == 2)
            {
                RetryCursor1.SetActive(false);
                RetryCursor2.SetActive(true);
                RetryCursor3.SetActive(false);

                if (Retrycount == 1)
                {

                }

            }

            //カーソルが３にある時の操作
            else if (Retrycount == 3)
            {
                RetryCursor1.SetActive(false);
                RetryCursor2.SetActive(false);
                RetryCursor3.SetActive(true);

                if (Retrycount == 2)
                {

                }
            }

            ////////////////
            ///カーソルの指して項目を選択した時に実行するコード


            bool Retrykettei = Input.GetKeyDown("joystick button 0");
            if (Retrykettei == true && Retrycount == 1)
            {

                //音(sound2)を鳴らす
                audioSource.PlayOneShot(sound2);

                Time.timeScale = 1;
                StartCoroutine("GoToGameScene");
            }
            else if (Retrykettei == true && Retrycount == 2)
            {
                //音(sound2)を鳴らす
                audioSource.PlayOneShot(sound2);

                Time.timeScale = 1;

                StartCoroutine("GoToTitleScene");
            }
            else if (Retrykettei == true && Retrycount == 3)
            {
                StartCoroutine("GameExit");
                Time.timeScale = 1;
            }


            ///カーソルの指して項目を選択した時に実行するコード終わり
            ////////////////
        }

    }
    IEnumerator GoToGameScene()
    {
        yield return new WaitForSeconds(0.57f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator GoToTitleScene()
    {
        yield return new WaitForSeconds(0.57f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator GameExit()
    {
        //音(sound2)を鳴らす
        audioSource.PlayOneShot(sound2);
        yield return new WaitForSeconds(0.57f);

        Application.Quit();
    }



}