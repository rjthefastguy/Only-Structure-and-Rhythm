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
    private GameObject cam;
    private float targetTime = 1.5f;
    private float colorTime = 0.25f;
    public float lingerTime = 0.5f;
    private float fspeed = 0.01f;
    private float fadechange = 0;
    private bool showtime = false;
    public bool vertical = true;
    private bool once = true;
    Color lerpedColor = Color.white;
    public float duration = 0.15f;
    public float magnitude = 0.5f;
    public float laserLength;
    //private float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScalechangeWH.y = (laserLength/1000);
        ScalechangeWV.x = (laserLength/1000);
        ScalechangeH.y = (laserLength/100);
        ScalechangeV.x = (laserLength/100);
        cam = GameObject.Find("Main Camera");
        if(vertical)
        {
            warning = transform.GetChild(0).gameObject;
        }
        else
        {
            warning = transform.GetChild(1).gameObject;
        }
        if(transform.parent != null)
        {
            transform.parent = null;
        }  
        sprite = GetComponent<SpriteRenderer>();
        m_spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    IEnumerator Shaking()
    {
        if(duration != 0f)
        {    
            Vector3 startPosition = cam.transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                if(vertical)
                {
                    float y = (Random.value - laserLength) * magnitude;
                    cam.transform.localPosition = new Vector3(startPosition.x, startPosition.y + y, startPosition.z);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                else
                {
                    float x = (Random.value - laserLength) * magnitude;
                    cam.transform.localPosition = new Vector3(startPosition.x + x, startPosition.y, startPosition.z);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
            cam.transform.localPosition = new Vector3 (0,0,-10f);
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if(Time.timeScale != 0)
        {
            Debug.Log("true");
            //counter += Time.deltaTime;
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
                    // Debug.Break();
                    // Debug.Log("Pause at " + counter);
                    //correcting the position at the start
                    Vector3 newposition = transform.localScale;
                    newposition.x = 0f;
                    transform.localScale = newposition;
                    once = false;
                }
                colorTime -= Time.deltaTime;
                //fading the color from white to red
                if (colorTime <= 0.0f)
                {
                    fadechange += fspeed;
                    lerpedColor = Color.Lerp(Color.white, Color.red, fadechange);
                    GetComponent<Renderer>().material.color = lerpedColor;
                }
                //lingering the laser for the time set
                lingerTime -= Time.deltaTime;
                if(lingerTime <= 0.0f)
                {
                    if(vertical)
                    {
                        //fading out the vertical laser
                        transform.localScale -= ScalechangeL;
                        if(transform.localScale.x <= 0.0f)
                        {
                            Destroy(gameObject);
                        }
                    }
                    else
                    {
                        //fading out the horizontal laser
                        transform.localScale -= ScalechangeLH;
                        if(transform.localScale.y <= 0.0f)
                        {
                            Destroy(gameObject);
                        }
                    }
                    
                }
                //vertical laser launching
                if(vertical)
                {
                    if(lingerTime > 0.0f)
                    {
                        transform.localScale += ScalechangeV;
                        if(transform.localScale.x >= laserLength)
                        {
                            Vector3 newpositionx = transform.localScale;
                            newpositionx.x = laserLength;
                            transform.localScale = newpositionx;
                        }
                        if(transform.localScale.y >= 25f)
                        {
                            Vector3 newpositiony = transform.localScale;
                            newpositiony.y = 22f;
                            transform.localScale = newpositiony;
                        }
                        else
                        {
                            StartCoroutine(Shaking());
                        }
                    }
                }
                //horizontal laser launching
                else
                {
                    if(lingerTime > 0.0f)
                    {
                        transform.localScale += ScalechangeH;
                        if(transform.localScale.y >= laserLength)
                        {
                            Vector3 newpositionx = transform.localScale;
                            newpositionx.y = laserLength;
                            transform.localScale = newpositionx;
                        }
                        if(transform.localScale.x >= 40f)
                        {
                            Vector3 newpositiony = transform.localScale;
                            newpositiony.x = 38f;
                            transform.localScale = newpositiony;
                        }
                        else
                        {
                            StartCoroutine(Shaking());
                        }
                    }
                }
            }
        }
    }
}
