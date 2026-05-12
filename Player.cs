using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    public int Maxhitpoint = 5;
    public int hitpoints;
    private bool isDead = false;
    private float invincframes = 1f;
    private float timer;
    private int children;
    public bool invinc = false;
    public bool nohit = false;
    private bool visi = false;
    private bool squish = false;
    private float timed;
    BoxCollider2D colliding;
    Rigidbody2D rb;
    Movement move;
    Renderer m_Renderer;
    private GameObject cam;
    private GameObject respawn;
    [Header("Color")]
    SpriteRenderer m_SpriteRenderer;
    Animator m_Animator;
    public Color m_IVColor;
    public Color m_HealthyColor;
    public Color m_DashColor;
    ParticleSystem m_ParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        respawn = GameObject.Find("Respawn point");
        m_Renderer = GetComponent<Renderer>();
        cam = GameObject.Find("Main Camera");
        hitpoints = Maxhitpoint;
        m_ParticleSystem = transform.GetComponentInChildren<ParticleSystem>();
        m_Animator = gameObject.GetComponent<Animator>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        colliding = GetComponent<BoxCollider2D>();
        move = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        if(visi)
        {
            move.noMove = true;
            move.moveInput = new Vector2(0,0);
            timed -= Time.deltaTime;
            if(timed < 0)
            {
                transform.position = respawn.transform.position;
                timer = invincframes;
                if (Input.anyKey)
                {
                    Debug.Log(rb.velocity);
                }
                if(Input.GetKey(KeyCode.DownArrow))
                {
                    rb.velocity = new Vector2(0,-1) * move.speed;
                    transform.up = new Vector2(0,-1).normalized;
                    squish = true;
                }
                else if(Input.GetKey(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector2(1,0) * move.speed;
                    transform.up = new Vector2(1,0).normalized;
                    squish = true;
                }
                else if(Input.GetKey(KeyCode.UpArrow))
                {
                    rb.velocity = new Vector2(0,1) * move.speed;
                    transform.up = new Vector2(0,1).normalized;
                    squish = true;
                }
                else if(Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector2(-1,0) * move.speed;
                    transform.up = new Vector2(-1,0).normalized;
                    squish = true;
                }
                else
                {
                    rb.velocity = new Vector2(0,0);
                }
                invinc = true;
                visi = false;
                move.noMove = false;
            }
        }
        if(squish)
        {
            transform.localScale = new Vector3(0.5f, 1f, 1f);
            if(rb.velocity == Vector2.zero)
            {
                squish = false;
            }
        }
        m_Animator.SetInteger("Health", hitpoints);
        if(invinc)
        {
            nohit = true;
            m_SpriteRenderer.color = m_IVColor;
            colliding.enabled = false;
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                invinc = false;
                nohit = false;
                colliding.enabled = true;
                m_SpriteRenderer.color = m_HealthyColor;
            }
        }
        if(nohit && !invinc)
        {
            m_SpriteRenderer.color = m_DashColor;
        }
        if(!nohit && !invinc)
        {
            m_SpriteRenderer.color = m_HealthyColor;
        }
        if(isDead)
        {
            if(transform.childCount < children)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnBecameInvisible()
    {
        timed = 0.75f;
        transform.position = new Vector3(transform.position.x,transform.position.y,-100);
        visi = true;
    }
    public void TakeHit(int damage)
    {
        timer = invincframes;
        invinc = true;
        hitpoints -= damage;
        if(hitpoints <= 0)
        {
            children = transform.childCount;
            m_ParticleSystem.Play();
            //Starts the animation for the other script
            isDead = true;
        }
        
    }
}
