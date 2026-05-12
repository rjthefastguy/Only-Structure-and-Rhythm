using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sizechanger : MonoBehaviour
{
    public float speed;
    Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += scaleChange * speed;
        // Move upwards when the sphere hits the floor or downwards
        // when the sphere scale extends 1.0f.
        if (transform.localScale.y < 0.1f || transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
        }
    }
}
