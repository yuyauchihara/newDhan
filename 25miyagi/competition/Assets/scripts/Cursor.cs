using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{

    [SerializeField] private GameObject Cursor1;
    [SerializeField] private GameObject Cursor2;
    [SerializeField] private GameObject Cursor3;
    int startflg = 0;
    int Cursorcount = 1;



    void Start()
    {
        Cursor2.SetActive(false);
        Cursor3.SetActive(false);
    }

    void Update()
    {

        ////////////////
        ///カーソルの位置を変えるコード

        bool up = Input.GetKeyDown("X-Axis");
        bool down = Input.GetKeyDown("Y-Axis");


        //L Stick
        //float lsh = Input.GetAxis("L_Stick_H");
        //float lsv = Input.GetAxis("L_Stick_V");
        //if ((lsh != 0) || (lsv != 0))
        //{

        //}

        if (Cursorcount == 1 && up == true)
        {
            Cursorcount = 3;
            Cursor1.SetActive(false);
            Cursor2.SetActive(true);
        }
        else if (Cursorcount == 1 && down == true)
        {
            Cursorcount = 2;
            Cursor1.SetActive(false);
            Cursor3.SetActive(true);
        }

        //カーソルが２にある時の操作
        else if (Cursorcount == 2 && up == true)
        {
            Cursorcount = 1;
            Cursor1.SetActive(false);
            Cursor2.SetActive(true);
        }
        else if (Cursorcount == 2 && down == true)
        {
            Cursorcount = 3;
            Cursor1.SetActive(false);
            Cursor3.SetActive(true);
        }

        //カーソルが３にある時の操作
        else if (Cursorcount == 3 && up == true)
        {
            Cursorcount = 2;
            Cursor1.SetActive(false);
            Cursor2.SetActive(true);
        }
        else if (Cursorcount == 2 && down == true)
        {
            Cursorcount = 1;
            Cursor1.SetActive(false);
            Cursor3.SetActive(true);
        }


        //カーソルが１にある時の操作


        ///カーソルの位置を変えるコード終わり
        ////////////////


        ////////////////
        ///カーソルの指して項目を選択した時に実行するコード

        bool kettei = Input.GetKeyDown("joystick button 0");
        if (kettei == true && Cursorcount == 1)
        {


        }
        else if (kettei == true && Cursorcount == 2)
        {


        }
        else if (kettei == true && Cursorcount == 3)
        {
            Application.Quit();

        }

        ///カーソルの指して項目を選択した時に実行するコード終わり
        ////////////////

    }
}

//X-Axis上（仮
//Y-Axis下（仮