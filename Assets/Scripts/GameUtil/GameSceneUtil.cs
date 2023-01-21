using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameSceneUtil : SingletonMonoBehaviour<GameSceneUtil>
{
    /// <summary>
    /// シーンを呼び出す
    /// </summary>
    /// <param name="sceneName"></param>
    public void SingleSceneTransration(string sceneName, UnityAction action = null)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        if (action != null) {
            action.Invoke();
        }
    }

    public GameObject[] NextSceneRootGetGameObjects
    {
        get
        {
            GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            return rootGameObjects;
        }
    }
}
