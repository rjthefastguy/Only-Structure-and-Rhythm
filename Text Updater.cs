using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{

    private Text HP;
    private Player points;

    void Start()
    {
        points = GameObject.Find("Player").GetComponent<Player>();
        HP = transform.GetComponentInChildren<Text>();
        //Text sets your text to say this message
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP: " + points.hitpoints.ToString(); 
    }
}
