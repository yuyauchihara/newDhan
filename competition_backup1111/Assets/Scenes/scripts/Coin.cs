
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


    void Start()
    {

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
        StartCoroutine("GameClearcount");

        Brb = ball.GetComponent<Rigidbody>();
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
            Time.timeScale = 0;
            Resultcount = 1;
            ResultPanel.SetActive(true);


            bool Resultkettei = Input.GetKeyDown("joystick button 1");
            if (Resultkettei == true & Resultcount == 1)
            {
                Resultcount = 0;
                Retrycount = 1;
                ResultPanel.SetActive(false);
                RetryPanel.SetActive(true);

            }
            x = Input.GetAxisRaw("Vertical");


            if (Retrycount == 1 && x == 1)
            {
                Retrycount = 3;
                RetryCursor1.SetActive(false);
                RetryCursor3.SetActive(true);

            }
            else if (Retrycount == 1 && x == -1)
            {
                Retrycount = 2;
                RetryCursor1.SetActive(false);
                RetryCursor2.SetActive(true);
            }

            //カーソルが２にある時の操作
            else if (Retrycount == 2 && x == 1)
            {
                Retrycount = 1;
                RetryCursor2.SetActive(false);
                RetryCursor1.SetActive(true);


            }
            else if (Retrycount == 2 && x == -1)
            {
                Retrycount = 3;
                RetryCursor2.SetActive(false);
                RetryCursor3.SetActive(true);

            }

            //カーソルが３にある時の操作
            else if (Retrycount == 3 && x == 1)
            {
                Retrycount = 2;
                RetryCursor3.SetActive(false);
                RetryCursor2.SetActive(true);

            }
            else if (Retrycount == 3 && x == -1)
            {
                Retrycount = 1;
                RetryCursor3.SetActive(false);
                RetryCursor1.SetActive(true);



            }

            ////////////////
            ///カーソルの指して項目を選択した時に実行するコード


            bool Retrykettei = Input.GetKeyDown("joystick button 0");
            if (Retrykettei == true && Retrycount == 1)
            {

                Time.timeScale = 1;
                SceneManager.LoadScene("SampleScene");
            }
            else if (Retrykettei == true && Retrycount == 2)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("TitleScene");
            }
            else if (Retrykettei == true && Retrycount == 3)
            {
                Application.Quit();
            }


            ///カーソルの指して項目を選択した時に実行するコード終わり
            ////////////////
        }



    }



}