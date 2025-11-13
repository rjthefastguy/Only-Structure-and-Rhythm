using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Natural movement")]
    [SerializeField] float speed = 5;
    private Rigidbody2D rb;
    public Vector2 moveInput;
    [Header("Knockback")]
    private bool reset = false;
    private bool noMove = false;
    [SerializeField] float strength = 16, delay = 0.15f;
    private float timer;
    [Header("Dashing")]
    private bool fast = true;
    [SerializeField] float startDashTime = 0.5f;
    [SerializeField] float dashSpeed = 10f;
    BoxCollider2D colliding;
    Player invincibility;
    TrailRender trail;
    private Particle Particle;
    float currentDashTime;
    bool canDash = true;
    bool playerCollision = true;
    

    
    // Start is called before the first frame update
    void Start()
    {
        Particle = GameObject.Find("ParticleP").GetComponent<Particle>();
        trail = transform.GetComponentInChildren<TrailRender>();
        colliding = GetComponent<BoxCollider2D>();
        invincibility = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(!playerCollision)
        // {
        //     colliding.enabled = false;
        // }
        // else
        // {
        //     colliding.enabled = true;
        // }
        currentDashTime -= Time.deltaTime;
        if(currentDashTime >  0)
        {
            rb.velocity = moveInput * dashSpeed;
        }
        if(currentDashTime < 0 && !canDash && !noMove)
        {
            trail.EndTrail();
            canDash = true;
            playerCollision = true;
            invincibility.nohit = false;
            fast = true;
            rb.velocity = moveInput * speed;
        }
        if(reset)
        {
            //transform.RotateAround(transform.position, Vector3.forward, 540 * Time.deltaTime);
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                //transform.rotation = Quaternion.Euler(0, 0, 0);
                noMove = false;
                rb.velocity = moveInput * speed;
                reset = false;
            }
        }
    }

    private void FixedUpdate()
    {

        if (moveInput != Vector2.zero && !noMove)
        {
            transform.up = moveInput.normalized;
            transform.localScale = new Vector3(0.5f, 1f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void OnHit(GameObject sender)
    {
        noMove = true;
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * strength, ForceMode2D.Impulse);
        timer = delay;
        reset = true;
    }
    private void OnDash(InputValue inputvalue)
    {
        if(canDash && !noMove)
        {
            if (moveInput != Vector2.zero) // Only rotate if there's actual movement
            {
                Dash(moveInput);
            }
        }
    }
    void Dash(Vector2 direction)
    {
        if(currentDashTime < 0)
        {
            Particle.Play();
            trail.StartTrail();
            canDash = false;
            playerCollision = false;
            invincibility.nohit = true;
            fast = false;
            currentDashTime = startDashTime; // Reset the dash timer.
        }
    }
    private void OnMove(InputValue inputvalue)
    {
        moveInput = inputvalue.Get<Vector2>();
        if(!noMove)
        {
            if(fast)
            {
                rb.velocity = moveInput * speed;
            }
        }
    }
}
