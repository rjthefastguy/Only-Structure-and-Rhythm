using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryLine : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;
    }

    public void SceneLoad()
    {
        StaticData.valueToKeep = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("VictoryScreen");
    }

    private void OnTriggerEnter2D  (Collider2D other)
    {
        SceneLoad();
    }
}

