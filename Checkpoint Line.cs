using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLine : MonoBehaviour
{
    private Player Player;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        Player.hitpoints = 8;
        Destroy(gameObject);
    }
}
