using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Text : MonoBehaviour
{
    public TMP_Text m_MyText;

    void Start()
    {
        //Text sets your text to say this message
        m_MyText.text = "This is my text";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
