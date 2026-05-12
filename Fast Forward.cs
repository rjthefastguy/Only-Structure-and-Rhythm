using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForward : MonoBehaviour
{
    
    AudioSource audioSource;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
            audioSource.pitch = 2;
            Time.timeScale = 2f;
            player.hitpoints = 8;
        }
        if(Input.GetKeyDown(KeyCode.Keypad5))
        {

            player.hitpoints = 8;
        }
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            audioSource.pitch = 1;
            Time.timeScale = 1f;
        }
        
    }
}
