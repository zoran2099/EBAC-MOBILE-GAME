using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneHelper : MonoBehaviour
{
    public void Load(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void Load(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
    }
}
