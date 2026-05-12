using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private string scene;
    private List<string> scenes = new List<string>();
    private string nextscene;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            scenes.Add(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CustomSceneLoad(string scene)
    {
         SceneManager.LoadScene(scene);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void SceneLoad()
    {
        scene = StaticData.valueToKeep;
        for(int i = 0; i < scenes.Count; i++)
        {
            if(scene == scenes[i])
            {
                nextscene = scenes[i+1];
            }
        }
        SceneManager.LoadScene(nextscene);
    }
}
