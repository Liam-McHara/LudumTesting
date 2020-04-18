using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    public string sceneToLoad = "MainScene";
    void Start()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}