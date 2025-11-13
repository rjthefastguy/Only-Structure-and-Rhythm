using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float transparent;
    private float fade = 0.0003f;
    private Vector3 ScalechangeWV = new Vector3(0.0005f,0f,0f);
    private Vector3 ScalechangeWH = new Vector3(0f,0.0005f,0f);
    private Vector3 ScalechangeV = new Vector3(0.005f,0.25f,0f);
    private Vector3 ScalechangeH = new Vector3(0.25f,0.005f,0f);
    private Vector3 ScalechangeL = new Vector3(0.005f,0f,0f);
    private Vector3 ScalechangeLH = new Vector3(0f,0.005f,0f);
    private SpriteRenderer m_spriteRenderer;
    private SpriteRenderer sprite;
    private GameObject warning;
    private float targetTime = 1.5f;
    private float colorTime = 0.25f;
    private float lingerTime = 0.5f;
    private float fspeed = 0.01f;
    private float fadechange = 0;
    private bool showtime = false;
    public bool vertical = true;
    private bool once = true;
    Color lerpedColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        if(vertical)
        {
            warning = transform.GetChild(0).gameObject;
        }
        else
        {
            warning = transform.GetChild(1).gameObject;
        }
        sprite = GetComponent<SpriteRenderer>();
        m_spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!showtime)
        {
            m_spriteRenderer.color = new Color(255f, 0f,0f, transparent);
            transparent += fade;
            if(vertical)
            {
                warning.transform.localScale += ScalechangeWV;
            }
            else
            {
                warning.transform.localScale += ScalechangeWH;
            }
            targetTime -= Time.deltaTime;
        }
        if (targetTime <= 0.0f)
        {
            Destroy(warning);
            showtime = true;
        }
        if(showtime)
        {
            if(once)
            {
                Vector3 newposition = transform.localScale;
                newposition.x = 0f;
                transform.localScale = newposition;
                once = false;
            }
            colorTime -= Time.deltaTime;
            if (colorTime <= 0.0f)
            {
                fadechange += fspeed;
                lerpedColor = Color.Lerp(Color.white, Color.red, fadechange);
                GetComponent<Renderer>().material.color = lerpedColor;
            }
            lingerTime -= Time.deltaTime;
            if(lingerTime <= 0.0f)
            {
                if(vertical)
                {
                    transform.localScale -= ScalechangeL;
                    if(transform.localScale.x <= 0.0f)
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    transform.localScale -= ScalechangeLH;
                    if(transform.localScale.y <= 0.0f)
                    {
                        Destroy(gameObject);
                    }
                }
                
            }
            if(vertical)
            {
                if(lingerTime > 0.0f)
                {
                    transform.localScale += ScalechangeV;
                    if(transform.localScale.x >= 0.5f)
                    {
                        Vector3 newpositionx = transform.localScale;
                        newpositionx.x = 0.5f;
                        transform.localScale = newpositionx;
                    }
                    if(transform.localScale.y >= 22f)
                    {
                        Vector3 newpositiony = transform.localScale;
                        newpositiony.y = 22f;
                        transform.localScale = newpositiony;
                    }
                }
            }
            else
            {
                if(lingerTime > 0.0f)
                {
                    transform.localScale += ScalechangeH;
                    if(transform.localScale.y >= 0.5f)
                    {
                        Vector3 newpositionx = transform.localScale;
                        newpositionx.y = 0.5f;
                        transform.localScale = newpositionx;
                    }
                    if(transform.localScale.y >= 38f)
                    {
                        Vector3 newpositiony = transform.localScale;
                        newpositiony.y = 38f;
                        transform.localScale = newpositiony;
                    }
                }
            }
        }
    }
}
