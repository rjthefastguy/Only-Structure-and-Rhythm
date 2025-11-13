using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionball : MonoBehaviour
{

    public float speed;
    Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed;
        if (!m_Renderer.isVisible)
        {
            Destroy(gameObject);
        }
        
    }

    void OnEnable()
    {
        transform.parent = null;
    }

}
