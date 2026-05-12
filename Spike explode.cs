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
    Transform parentTransform;
    private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        parentTransform = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(move)
        {
            transform.position = Vector2.Lerp(transform.position, endpoint.transform.position, .05f);
        }
        if(parentTransform.parent != null)
        {
            if(counter >= 0.5f)
            {
                Boom();
            }
        }
        if(Vector2.Distance(transform.position, endpoint.transform.position) <= 0.2f)
        {
            if(parentTransform.parent == null)
            {
                boom = true;
            }
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
        for (int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
