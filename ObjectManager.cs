using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // List to store all objects (active and inactive)
    public List<GameObject> allObjects = new List<GameObject>();
    private bool loop = false;
    private float counter = 0;

    void Awake()
    {
        // Recursively add all objects in the scene
        allObjects.Clear();
        foreach (GameObject root in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            AddChildrenRecursive(root);
        }
        loop = true;
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(loop)
        {
            allObjects.RemoveAll( x => !x);
        }
    }
    void AddChildrenRecursive(GameObject obj)
    {
        allObjects.Add(obj);
        foreach (Transform child in obj.transform)
        {
            AddChildrenRecursive(child.gameObject);
        }
    }

    // Get object by name
    public GameObject GetObjectByName(string name)
    {
        return allObjects.Find(obj => obj.name == name);
    }

    // Example: Activate and play animation
    public void Activate(string objectName)
    {
        GameObject obj = GetObjectByName(objectName);
        if (obj != null)
        {
            obj.SetActive(true);
        }
        // else
        // {
        //     Debug.LogWarning("Object not found: " + objectName);
        // }
    }
    public void Deactivate(string objectName)
    {
        GameObject obj = GetObjectByName(objectName);
        if (obj != null)
        {
            obj.SetActive(false);
        }
        // else
        // {
        //     Debug.LogWarning("Object not found: " + objectName);
        // }
    }

    public void Pause()
    {
        Debug.Break();
        Debug.LogError("Pause at " + counter);
    }
}

