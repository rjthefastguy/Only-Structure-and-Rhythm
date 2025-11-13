using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK : MonoBehaviour
{
    [SerializeField] int damage = 1;
    private Player Player;
    private Movement PlayerM;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Player>();
        PlayerM = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!Player.nohit)
        {
            Player.TakeHit(damage);
            PlayerM.OnHit(gameObject);
        }
    }

}
