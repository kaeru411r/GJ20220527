using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    /// <summary>�^�C�g���V�[��</summary>
    private Scene _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(0);

    private Scene _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(1);

    /// <summary>���݂̃V�[��</summary>
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    /// <summary>
    /// ���̃V�[����������x
    /// </summary>
    public void Playback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nowScene.name);
    }

    /// <summary>
    /// ���̃V�[�������[�h
    /// </summary>
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nowScene.buildIndex + 1);
    }

    /// <summary>
    /// �^�C�g���V�[����
    /// </summary>
    public void Title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_titleScene.name);
    }

    /// <summary>
    /// ���U���g�V�[����
    /// </summary>
    public void Result()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_resultScene.name);
    }

    public void Optionally(int value)
    {
        int count = UnityEngine.SceneManagement.SceneManager.sceneCount;
        value = Mathf.Min(value, count);
        value = Mathf.Max(value, 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(value);
    }
}
