﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // public List<Object> keepList;


    // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0; i < keepList.Count; i++)
        // {
        //     if(keepList[i] == null)
        //     {
        //         keepList.RemoveAt(i);
        //         continue;
        //     }
        // 
        //     Object.DontDestroyOnLoad(keepList[i]);
        // }
    }

    // adds object to "Do Not Destroy on Load" list.
    // public void AddObjectToDontDestroyOnLoadList(Object entity)
    // {
    //     Object.DontDestroyOnLoad(entity);
    //     keepList.Add(entity);
    // }
    
    // gets the name of the active scene
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    // gets the scene name
    public static string GetSceneName(int index)
    {
        // scene
        Scene scene = SceneManager.GetSceneAt(index);

        // if scene was found.
        if (scene != null)
            return scene.name;
        else
            return null;
    }
   
    // changes the scene using an index.
    // TODO: make static
    public static void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    // changes the scene using a string
    public static void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BackChangeCanvas(string canvas)
    {
        var temp = GameObject.Find(canvas);
        temp.GetComponent<Canvas>().enabled = false;

    }

    public void ChangeCanvas(string canvas)
    {
        var temp = GameObject.Find(canvas);
        temp.GetComponent<Canvas>().enabled = true;
     
    }

    // switches out an active game object for an inactive one.
    public void SwitchActiveGameObject(string current, string next)
    {
        GameObject g0 = GameObject.Find(current);
        GameObject g1 = GameObject.Find(next);

        g0.SetActive(false);
        g1.SetActive(true);
    }

    // returns the skybox
    public Material GetSkybox()
    {
        return RenderSettings.skybox;
    }

    public void SetSkybox(Material newSkybox)
    {
        RenderSettings.skybox = newSkybox;
    }

    // exits the game
    public void ExitApplication()
    {
        Application.Quit();
    }

}
