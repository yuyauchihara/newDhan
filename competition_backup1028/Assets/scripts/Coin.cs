using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour
{
    //public GameObject unlockObj;
    public TextMeshProUGUI countText;

    private int count;


    void Start()
    {

        count = 0;
        //countText.text = "0/12" + count.ToString();
        //countText.text = count.ToString() + "/12";
        Score();
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
        }

    }
    void Score()
    {
        countText.text = count.ToString() + "/12";
    }
}