using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDisable()
    {
        Destroy(gameObject);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
