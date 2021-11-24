using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Cursor : MonoBehaviour
{

    [SerializeField] private GameObject Cursor1;
    [SerializeField] private GameObject Cursor2;
    [SerializeField] private GameObject Cursor3;
    int startflg = 0;
    int Cursorcount = 1;
    float x;

    float af = 0, df = 0;
    int Stet = 1;


    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    public bool DontDestroyEnabled = true;

    //カウントアップ
    private float countup = 0.0f;

    void Start()
    {
        Cursorcount = 1;
        Cursor2.SetActive(false);
        Cursor3.SetActive(false);


        audioSource = GetComponent<AudioSource>();

        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        ////////////////
        ///カーソルの位置を変えるコード
        ///

        Debug.Log(Cursorcount);

        x = Input.GetAxisRaw("Vertical");

        //カーソルの位置の処理、連続入力の防止ここから

        //スティックが上
        if (x > 0)
        {
            af++;//上入力の間加算し続ける

            if (af == 1)//afが加算され続けている時、その値が1の瞬間のみ以下の処理を行う。故に連続入力の対策となる
            {
                Cursorcount--;

                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
            }
        }
        else
        {
            af = 0;//スティックが離されるか別入力になったら0にする
        }
        //カーソルが１の時に更に上に上げられたらカーソルの位置を３に移動させる
        if (Cursorcount <= 0)
        {
            Cursorcount = 3;
        }

        //スティックが下
        if (x < 0)
        {
            df++;//下入力の間加算を続ける

            if (df == 1)
            {
                Cursorcount++;

                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
            }
        }
        else
        {
            df = 0;
        }
        if (Cursorcount >= 4)
        {
            Cursorcount = 1;
        }
        //カーソルの位置の処理、連続入力の防止ここまで


        //カーソルが1
        if (Cursorcount == 1)
        {
            Cursor1.SetActive(true);
            Cursor2.SetActive(false);
            Cursor3.SetActive(false);

        }

        //カーソルが２にある時の操作
        else if (Cursorcount == 2)
        {
            Cursor1.SetActive(false);
            Cursor2.SetActive(true);
            Cursor3.SetActive(false);

            if (Cursorcount == 1)
            {

            }

        }

        //カーソルが３にある時の操作
        else if (Cursorcount == 3)
        {
            Cursor1.SetActive(false);
            Cursor2.SetActive(false);
            Cursor3.SetActive(true);

            if (Cursorcount == 2)
            {

            }
        }


        //カーソルが１にある時の操作


        ///カーソルの位置を変えるコード終わり
        ////////////////

        ////////////////
        ///カーソルの指して項目を選択した時に実行するコード

        
        bool kettei = Input.GetKeyDown("joystick button 0");


        if (kettei == true && Cursorcount == 1)
        {
            //音(sound2)を鳴らす
            audioSource.PlayOneShot(sound2);

            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");

            Destroy(this);
        }
        if (kettei == true && Cursorcount == 2)
        {
            //音(sound2)を鳴らす
            audioSource.PlayOneShot(sound2);

            Time.timeScale = 1;
            SceneManager.LoadScene("Title");

            Destroy(this);
        }
        if (kettei == true && Cursorcount == 3)
        {
            //音(sound2)を鳴らす
            audioSource.PlayOneShot(sound2);

            Application.Quit();
        }
        

        ///カーソルの指して項目を選択した時に実行するコード終わり
            ////////////////


    }
}