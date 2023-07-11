using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    Scene currentScene;

    public Animator fadeTransition, musicFade;
    public float fadeHalfDuration = 1f;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void LoadNextSceneIndex()
    {
        StartCoroutine(FadeToScene(currentScene.buildIndex + 1));
    }

    public void LoadSceneName(string sceneName)
    {
        Debug.Log(sceneName);
        Debug.Log(SceneManager.GetSceneByName(sceneName).buildIndex);
        StartCoroutine(FadeToScene(SceneManager.GetSceneByName(sceneName).buildIndex));
    }

    public void LoadSceneIndex(int sceneIndex)
    {
        StartCoroutine(FadeToScene(sceneIndex));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator FadeToScene(int sceneIndex)
    {
        if (fadeTransition != null)
            fadeTransition.SetTrigger("Start");
        if (musicFade != null)
            musicFade.SetTrigger("StopAudio");

        yield return new WaitForSeconds(fadeHalfDuration);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
