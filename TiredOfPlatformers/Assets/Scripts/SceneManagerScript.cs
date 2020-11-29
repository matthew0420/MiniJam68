using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerScript : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadAScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}