using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public int Maxhitpoint = 5;
    public int hitpoints;
    //private bool isDead = false;
    public float invincframes = 1f;
    private float timer;
    public bool invinc = false;
    public bool nohit = false;
    BoxCollider2D colliding;
    Rigidbody2D rb;
    Movement move;
    SpriteRenderer m_SpriteRenderer;
    public Color m_IVColor;
    public Color m_HealthyColor;
    public Color m_DashColor;
    
    // [SerializeField] Sprite[] HPSprites;
    // [SerializeField] Sprite currentSprites;

    // Start is called before the first frame update
    void Start()
    {
        hitpoints = Maxhitpoint;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        colliding = GetComponent<BoxCollider2D>();
        move = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public void TakeHit(int damage)
    {
        invinc = true;
        hitpoints -= damage;
        timer = invincframes;
        if(hitpoints <= 0)
        {
            //Starts the animation for the other script
            //isDead = true;
        }
        
    }
}
