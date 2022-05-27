using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    /// <summary>タイトルシーン</summary>
    private Scene _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(0);

    private Scene _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(1);

    /// <summary>現在のシーン</summary>
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    /// <summary>
    /// 今のシーンをもう一度
    /// </summary>
    public void Playback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nowScene.name);
    }

    /// <summary>
    /// 次のシーンをロード
    /// </summary>
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_nowScene.buildIndex + 1);
    }

    /// <summary>
    /// タイトルシーンへ
    /// </summary>
    public void Title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_titleScene.name);
    }

    /// <summary>
    /// リザルトシーンへ
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
