using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneManager : SingletonMonoBehaviour<SceneManager>
{
    /// <summary>タイトルシーン</summary>
    private Scene _titleScene;

    private Scene _resultScene;

    /// <summary>現在のシーン</summary>
    private Scene _nowScene;

    private void Awake()
    {
        base.Awake();
        _titleScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(0);
        _resultScene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(1);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }

    /// <summary>
    /// 今のシーンをもう一度
    /// </summary>
    public void Playback()
    {
        SceneChange(_nowScene.buildIndex);
    }

    /// <summary>
    /// 次のシーンをロード
    /// </summary>
    public void NextScene()
    {
        SceneChange(_nowScene.buildIndex + 1);
    }

    /// <summary>
    /// タイトルシーンへ
    /// </summary>
    public void Title()
    {
        SceneChange(_titleScene.buildIndex);
    }

    /// <summary>
    /// リザルトシーンへ
    /// </summary>
    public void Result()
    {
        SceneChange(_resultScene.buildIndex);
    }

    /// <summary>
    /// 指定したシーンに移動
    /// </summary>
    /// <param name="value"></param>
    public void Optionally(int value)
    {
        int count = UnityEngine.SceneManagement.SceneManager.sceneCount;
        value = Mathf.Min(value, count - 1);
        value = Mathf.Max(value, 0); 
        SceneChange(value);
    }

    /// <summary>
    /// シーンを遷移
    /// </summary>
    /// <param name="num"></param>
    void SceneChange(int num)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(num);
        _nowScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
}
