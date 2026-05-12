using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashControl : MonoBehaviour
{
    [SerializeField] float startDashTime = 1f;
    [SerializeField] float dashSpeed = 1f;
    private Vector2 moveInput;
    BoxCollider2D colliding;
    Rigidbody2D rb;
    Movement move;
    Player invincibility;

    float currentDashTime;

    bool canDash = true;
    bool playerCollision = true;

    void Start()
    {
        colliding = GetComponent<BoxCollider2D>();
        move = GetComponent<Movement>();
        invincibility = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!playerCollision)
        {
            colliding.enabled = false;
        }
        else
        {
            colliding.enabled = true;
        }
    }

    IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        playerCollision = false;
        invincibility.nohit = true;
        move.fast = false;
        currentDashTime = startDashTime; // Reset the dash timer.

        while (currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime;

            rb.velocity = moveInput * dashSpeed; // Dash in the direction that was held down.
            // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.

            yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
        }

        rb.velocity = new Vector2(0f, 0f); // Stop dashing.

        canDash = true;
        playerCollision = true;
        invincibility.nohit = false;
        move.fast = true;
    }
    private void OnMove(InputValue inputvalue)
    {
        moveInput = inputvalue.Get<Vector2>();
    }

    private void OnFire(InputValue inputvalue)
    {
        if(canDash)
        {
            if (moveInput != Vector2.zero) // Only rotate if there's actual movement
            {
                StartCoroutine(Dash(moveInput));
            }
        }
        
 
    }
}