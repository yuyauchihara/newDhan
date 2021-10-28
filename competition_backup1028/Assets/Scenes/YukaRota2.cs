using UnityEngine;

public class objectMoving : MonoBehaviour
{
    public float wSpeed = 10;
    public float sSpeed = 7;
    public float adRotate = 100;
    float yRotate = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 0, wSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, 0, -sSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            yRotate = Mathf.Clamp(yRotate + adRotate * Time.deltaTime, -90, 90);
            transform.eulerAngles = new Vector3(0, yRotate, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            yRotate = Mathf.Clamp(yRotate - adRotate * Time.deltaTime, -90, 90);
            transform.eulerAngles = new Vector3(0, yRotate, 0);
        }
    }
}