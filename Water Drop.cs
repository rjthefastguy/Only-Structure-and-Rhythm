using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private Vector3 ScaleChange = new Vector3(0.02f,0.02f,0.02f);
    private float speed = 1.5f;
    private float timer = 4;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0,0,0);
        timer = timer/speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += ScaleChange * speed * Time.deltaTime;
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        float timed = 0.25f;
        timed -= Time.deltaTime;
        if(timed < 0)
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = true;
        }
    }
}
