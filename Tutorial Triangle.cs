using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTriangle : MonoBehaviour
{
    public int rspeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.RotateAround(transform.position, Vector3.forward, rspeed * Time.deltaTime);
    }
}
