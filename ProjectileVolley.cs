using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVolley : MonoBehaviour
{
    private float count = 0;
    public bool loop = false;
    public bool speed = false;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
       m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(loop)
        {
            m_Animator.SetBool("Loop", true);
        }
        if(speed)
        {
            m_Animator.SetBool("Speed", true);
        }
        if(transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Throw()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
