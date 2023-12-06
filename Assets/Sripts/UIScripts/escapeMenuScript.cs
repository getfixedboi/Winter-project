using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeMenuScript : MonoBehaviour
{
    private const int mainMenuSceneIndex = 0;

    [Header ("Scripts references")]
    [SerializeField] colliderScript colliderScript;
    [SerializeField] inputScript inputScript;

    [Header ("canvasEscapeMenu reference")]
    [SerializeField] private GameObject PauseMenu;

    void Start()
    {
        PauseMenu.SetActive(false);
    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        inputScript.isPressedEsc = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        colliderScript.appleCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Quit()
    {
        colliderScript.appleCount = 0;
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}