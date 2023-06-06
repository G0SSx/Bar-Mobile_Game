using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner) => 
        _coroutineRunner = coroutineRunner;

    public void Load(string nextScene, Action onLoaded = null) =>
        _coroutineRunner.StartCoroutine(LoadScene(nextScene, onLoaded));

    public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == nextScene)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (waitNextScene.isDone == false)
            yield return null;

        onLoaded?.Invoke();
    }
}