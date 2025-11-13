using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private GameObject player;
    private Movement Move;
    private float timer = 0.0f;
    ParticleSystem m_ParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        Move = GameObject.Find("Player").GetComponent<Movement>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0)
        {
            transform.up = Move.moveInput.normalized;
        }
    }

    public void Play()
    {
        timer = 0.5f;
        transform.position = player.transform.position;
        m_ParticleSystem.Play();

    }
}
