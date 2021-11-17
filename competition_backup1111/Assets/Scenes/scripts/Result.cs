
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{

    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject RetryPanel;

    [SerializeField] private GameObject RetryCursor1;
    [SerializeField] private GameObject RetryCursor2;
    [SerializeField] private GameObject RetryCursor3;

    int startflg = 0;
    int Resultcount = 0;
    int Retrycount = 0;
    float x;


    void Start()
    {
        RetryPanel.SetActive(false);

        RetryCursor2.SetActive(false);
        RetryCursor3.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        bool Resultkettei = Input.GetKeyDown("joystick button 1");
        if (Resultkettei == true)
        {
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

            if (Retrycount == 1)
            {

            }

        }
        else if (Retrycount == 2 && x == -1)
        {
            Retrycount = 3;
            RetryCursor2.SetActive(false);
            RetryCursor3.SetActive(true);

            if (Retrycount == 3)
            {

            }
        }

        //カーソルが３にある時の操作
        else if (Retrycount == 3 && x == 1)
        {
            Retrycount = 2;
            RetryCursor3.SetActive(false);
            RetryCursor2.SetActive(true);

            if (Retrycount == 2)
            {

            }
        }
        else if (Retrycount == 3 && x == -1)
        {
            Retrycount = 1;
            RetryCursor3.SetActive(false);
            RetryCursor1.SetActive(true);


            if (Retrycount == 1)
            {

            }

        }

        ////////////////
        ///カーソルの指して項目を選択した時に実行するコード


        bool Retrykettei = Input.GetKeyDown("joystick button 0");
        if (Retrykettei == true && Retrycount == 1)
        {


        }
        else if (Retrykettei == true && Retrycount == 2)
        {

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