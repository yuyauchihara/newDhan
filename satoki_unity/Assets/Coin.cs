using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public GameObject unlockObj;
    public TextMeshProUGUI countText;

    private int count;

    void Start()
    {
        count = 0;
        //countText.text = "0/12" + count.ToString();
        countText.text = count.ToString() + "/12";
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            //unlockObj.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            count++;
            //countText.text = "0/12" + count.ToString();
            countText.text = count.ToString() + "/12";

        }
    }
}
