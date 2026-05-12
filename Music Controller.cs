using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicController : MonoBehaviour
{
    private AudioSource AudioSource;
    public float stopwatch;
    private bool playing = false;
    public Silence mute;
    public float currentvolume;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        currentvolume = AudioSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if(playing)
        {
            stopwatch += Time.deltaTime; 
        }
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Debug.Log("point at " + stopwatch);
        }
        if(!mute.silence)
        {
            AudioSource.volume -= 0.0005f;
        }
        
    }
    void OnEnable()
    {
        playing = true;
    }

    public void Mute()
    {
        currentvolume = AudioSource.volume;
        AudioSource.volume = 0;
    }
    public void Unmute()
    {
        AudioSource.volume = currentvolume;
    }
    public void Pause()
    {
        if(AudioSource.pitch != 0)
        {
            AudioSource.pitch = 0;
        }
        else
        {

            AudioSource.pitch = 1;
        }
    }
}
