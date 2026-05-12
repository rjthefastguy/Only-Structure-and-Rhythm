using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBoxes : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public string direction;
    // Start is called before the first frame update
    void Start()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
        Vector3 viewPos = transform.position;
        if(direction == "r")
        {
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x + objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;
        }
        else if(direction == "l")
        {
            viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x -objectWidth, -screenBounds.x -objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;
        }
        else if(direction == "u")
        {
            viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y + objectHeight);
            transform.position = viewPos;
        }
        else if(direction == "d")
        {
            viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y - objectHeight, -screenBounds.y - objectHeight);
            transform.position = viewPos;
        }
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
