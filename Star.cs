using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int rspeed = 20;
    public int mspeed = 5;
    public int min;
    public int max;
    public bool vertical = false;
    public bool randspeed = false;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        if(transform.parent != null)
        {
            if(randspeed)
            {
               mspeed = Random.Range(min,max); 
            }
            transform.parent = null;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.RotateAround(transform.position, Vector3.forward, rspeed * Time.deltaTime);
        if(vertical)
        {
            pos.y -= mspeed * Time.deltaTime;
        }
        else
        {
            pos.x -= mspeed * Time.deltaTime;
        }
        transform.position = pos;
        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
        
    }
}
