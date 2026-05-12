using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject cam;
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public float speed = .0045f;
    public bool reset = false;
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        // left = cam.transform.Find("LeftBox").gameObject;
        // right = cam.transform.Find("RighttBox").gameObject;
        // up = cam.transform.Find("UpBox").gameObject;
        // down = cam.transform.Find("DownBox").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == "r")
        {
            cam.transform.position += cam.transform.right * speed;
            left.SetActive(true);
            //right.SetActive(false);
            up.SetActive(true);
            down.SetActive(true);
        }
        else if(direction == "l")
        {
            cam.transform.position -= cam.transform.right * speed;
            right.SetActive(true);
            //left.SetActive(false);
            up.SetActive(true);
            down.SetActive(true);
        }
        else if(direction == "u")
        {
            cam.transform.position += cam.transform.up * speed;
            down.SetActive(true);
            left.SetActive(true);
            right.SetActive(true);
            //up.SetActive(false);
        }
        else if(direction == "d")
        {
            cam.transform.position -= cam.transform.up * speed;
            up.SetActive(true);
            left.SetActive(true);
            right.SetActive(true);
            //down.SetActive(false);
        }
        else
        {
            //up.SetActive(false);
            //right.SetActive(false);
            //left.SetActive(false);
            //down.SetActive(false);
        }
        
        if(reset)
        {
            speed = 0;
            cam.transform.position = new Vector3(0,0,-10);
            reset = false;
        }
    }
}
