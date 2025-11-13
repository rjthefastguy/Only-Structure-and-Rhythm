using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float rspeed = 20;
    public float mspeed = 5;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.RotateAround(transform.position, Vector3.forward, rspeed * Time.deltaTime);
        pos.x -= mspeed * Time.deltaTime;
        transform.position = pos;
        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
        
    }
}
