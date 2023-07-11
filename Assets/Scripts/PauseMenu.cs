using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Animator _animator;

    [SerializeField]
    GameObject pauseMenuUI;

    [SerializeField]
    GameObject virtualCamera;

    [SerializeField]
    LoadNextScene _loadNextScene;

    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        //_animator = GetComponent<Animator>();

        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                Continue();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                if (virtualCamera != null) virtualCamera.SetActive(false);
                isPaused = true;
            }
        }
        //_animator.SetBool("isPaused", isPaused);
    }

    public void Continue()
    {
        pauseMenuUI.SetActive(false);
        if (virtualCamera != null) virtualCamera.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        _loadNextScene.LoadSceneIndex(0);
    }
}
