using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject TitlePanel;

    void Start()
    {

    }
    void Update()
    {
        bool Startkettei = Input.GetKeyDown("joystick button 0");
        if (Startkettei == true)
        {
            SceneManager.LoadScene("SampleScene");
            TitlePanel.SetActive(false);
        }
    }
}
