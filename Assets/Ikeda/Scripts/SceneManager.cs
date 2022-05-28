using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    /// <summary>�^�C�g���V�[��</summary>
    private Scene _titleScene;

    private Scene _resultScene;

    /// <summary>���݂̃V�[��</summary>
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(0);
        _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(1);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    /// <summary>
    /// ���̃V�[����������x
    /// </summary>
    public void Playback()
    {
        SceneChange(_nowScene.buildIndex);
    }

    /// <summary>
    /// ���̃V�[�������[�h
    /// </summary>
    public void NextScene()
    {
        SceneChange(_nowScene.buildIndex + 1);
    }

    /// <summary>
    /// �^�C�g���V�[����
    /// </summary>
    public void Title()
    {
        SceneChange(_titleScene.buildIndex);
    }

    /// <summary>
    /// ���U���g�V�[����
    /// </summary>
    public void Result()
    {
        SceneChange(_resultScene.buildIndex);
    }

    public void Optionally(int value)
    {
        int count = UnityEngine.SceneManagement.SceneManager.sceneCount;
        value = Mathf.Min(value, count);
        value = Mathf.Max(value, 0); 
        SceneChange(value);
    }

    void SceneChange(int num)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(num);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
