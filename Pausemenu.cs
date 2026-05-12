using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{

    public GameObject container;
    public GameObject Mute,Unmute;
    public MusicController muting;
    public bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
            if(muting != null)
            {
                muting.Pause();
            }
            
        }
        if(container.activeSelf)
        {
            paused = true;
        }
        else
        {
            paused = false;
        }
    }

    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
        if(muting != null)
        {
            muting.Pause();
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void MuteButton()
    {
        if(muting != null)
        {
            muting.Mute();
            
        }
        Mute.SetActive(false);
        Unmute.SetActive(true);
    }
    public void UnmuteButton()
    {
        if(muting != null)
        {
            muting.Unmute();
        }
        Mute.SetActive(true);
        Unmute.SetActive(false);
    }
}
