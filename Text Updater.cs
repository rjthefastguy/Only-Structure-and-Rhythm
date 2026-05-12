using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdater : MonoBehaviour
{

    private TMP_Text HP;
    private MusicController points;

    void Start()
    {
        HP = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points = GameObject.Find("Music Player").GetComponent<MusicController>();
        //FormatProvider format = float.ToString(000.00);
        HP.text = "StopWatch: " + points.stopwatch.ToString("N3");
    }
}
