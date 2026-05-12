using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTeleport : MonoBehaviour
{
    private GameObject cam;
    public GameObject TPSpot;
    private ObjectManager boom;
    private Player Player;
    public TMP_Text m_TextComponent;
    public string block;
    public string activation,activation2, deactivation;
    public int mspeed = 5;
    public float timer;
    public float timer2;
    // Start is called before the first frame update
    void Start()
    {
        boom = GetComponent<ObjectManager>();
        Player = GameObject.Find("Player").GetComponent<Player>();
        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer2 -= Time.deltaTime;
            if(timer2 > 0)
            {
                Vector3 pos = transform.position;
                pos.x -= mspeed * Time.deltaTime;
                transform.position = pos;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        cam.transform.position = new Vector3(TPSpot.transform.position.x,TPSpot.transform.position.y,-10);
        m_TextComponent.text = block;
        Player.hitpoints = 8;
        boom.Activate(activation);
        boom.Activate(activation2);
        boom.Deactivate(deactivation);
        Destroy(gameObject);
    }
}
