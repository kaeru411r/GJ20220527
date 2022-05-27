using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    public void Playback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nowScene.name);
    }
}
