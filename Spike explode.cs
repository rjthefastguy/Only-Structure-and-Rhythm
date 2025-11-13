using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikeexplode : MonoBehaviour
{
    private bool explode = false;
    private bool boom = false;
    public bool move = false;
    [SerializeField] GameObject endpoint;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.position = Vector2.Lerp(transform.position, endpoint.transform.position, .05f);
        }
        if(Vector2.Distance(transform.position, endpoint.transform.position) <= 0.2f)
        {
            boom = true;
        }
        if(boom)
        {
            m_Animator.SetBool("Explode", true);
        }
        if(explode)
        {
            Explode();
        }
        if(transform.childCount == 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void Boom()
    {
        explode = true;
    }
    void Explode()
    {
        for (int i=0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
