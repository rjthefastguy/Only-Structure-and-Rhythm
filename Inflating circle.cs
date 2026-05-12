using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflatingcircle : MonoBehaviour
{
    private Vector3 scaleChange, scaleLinger;
    private Vector3 radius;
    private bool timer = true;
    private bool grow = true;
    public bool fade = false;
    public float change;
    public float ling;
    public float circle;
    public float fspeed;
    private float fadechange = 0;
    public bool raise = false;
    [SerializeField] float targetTime = 2.6f;
    Color lerpedColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(change,change,change);
        scaleLinger = new Vector3(ling,ling,ling);
        radius = new Vector3(circle,circle,circle);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if(raise)
            {
                if (grow && transform.localScale.y <= radius.y)
                {
                    show();
                }
                else if(timer)
                {

                    linger();
                }
                else
                {
                    hide();
                }
            }
        }
    }

    void show()
    {
        transform.localScale += scaleChange;    
        if(fade)
        {
            fadechange += fspeed;
            lerpedColor = Color.Lerp(Color.red, Color.white, fadechange);
            GetComponent<Renderer>().material.color = lerpedColor;
        }
    }
    void linger()
    {
        grow = false;
        transform.localScale += scaleLinger;
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            timer = false;
        }
    }
    void hide()
    {
        transform.localScale -= scaleChange;
        if(fade)
        {
            fadechange -= fspeed;
            lerpedColor = Color.Lerp(Color.red, Color.white, fadechange);
            GetComponent<Renderer>().material.color = lerpedColor;
        }
        if(transform.localScale.y <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
