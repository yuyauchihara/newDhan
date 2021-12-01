using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{

    [SerializeField] private GameObject pausePanel;
    public GameObject curObj;
    Cursor cur;
    int startflg = 0;
    int Pausecount = 0;
    int posesc;


    void Start()
    {
        pausePanel.SetActive(false);
        cur = curObj.GetComponent<Cursor>();

        posesc = 0;
    }

    void Update()
    {

        posesc++;
        bool start = Input.GetKeyDown("joystick button 7");

        if (start == true && Pausecount == 0 && posesc >= 240)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            Pausecount = 1;

        }
        else if (start == true && Pausecount == 1)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            Pausecount = 0;

        }

        if (pausePanel.activeSelf == false)
        {
            cur.enabled = false;
        }
        else
        {
            cur.enabled = true;
        }
    }
}