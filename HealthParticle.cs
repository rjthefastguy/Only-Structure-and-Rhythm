using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParticle : MonoBehaviour
{

    Player player;
    private ParticleSystem ps;
    private int health;
    private bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponentInParent<Player>();
        ps = GetComponent<ParticleSystem>();
    }

    void once()
    {
        if(one)
        {
            ps.Play(); 
            one = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        health = player.hitpoints;
        if(health == 8)
        {
            ps.Stop();
            one = true;
        }
        if(health != 8)
        {
            once();
        }
        var emission = ps.emission;
        if(health == 7)
        {
            emission.rateOverTime = 4;
        }
        if(health == 6)
        {
            emission.rateOverTime = 8;
        }
        if(health == 5)
        {
            emission.rateOverTime = 12;
        }
        if(health == 4)
        {
            emission.rateOverTime = 16;
        }
        if(health == 3)
        {
            emission.rateOverTime = 20;
        }
        if(health == 2)
        {
            emission.rateOverTime = 24;
        }
        if(health == 1)
        {
            emission.rateOverTime = 50;
        }
        if(health == 0)
        {
            ps.Stop();
        }
    }
}
