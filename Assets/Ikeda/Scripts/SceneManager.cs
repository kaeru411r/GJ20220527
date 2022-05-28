using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

/// <summary>
/// �V�[���̑@�ۂ��Ǘ�����R���|�[�l���g
/// </summary>
public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    /// <summary>�^�C�g���V�[��</summary>
    private Scene _titleScene;
    /// <summary>���U���g�V�[��</summary>
    private Scene _resultScene;
    /// <summary>�S�N���V�[��</summary>
    private Scene _clearScene;

    /// <summary>���݂̃V�[��</summary>
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        int count = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        Debug.Log(count);
        _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(0);
        _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(1);
        _clearScene = UnityEngine.SceneManagement.SceneManager.GetSceneByBuildIndex(2);
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

    public void Clear()
    {
        SceneChange(_clearScene.buildIndex);
    }

    /// <summary>
    /// �w�肵���V�[���Ɉړ�
    /// </summary>
    /// <param name="value"></param>
    public void Optionally(int value)
    {
        int count = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        value = Mathf.Min(value, count - 1);
        value = Mathf.Max(value, 0); 
        SceneChange(value);
    }

    /// <summary>
    /// �V�[����J��
    /// </summary>
    /// <param name="num"></param>
    void SceneChange(int num)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(num);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
