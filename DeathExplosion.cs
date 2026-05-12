using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathExplosion : MonoBehaviour
{
    private ParticleSystem ps;
    SceneLoader SceneLoader;
    private bool go = false;
    public float timer = 2.3f;
    // Start is called before the first frame update
    void Start()
    {
        SceneLoader = GetComponent<SceneLoader>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.isPlaying)
        {
            transform.parent = null;
            go = true;
        }
        if(go)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SceneLoader.SceneLoad();
            }
        }
    }
}
