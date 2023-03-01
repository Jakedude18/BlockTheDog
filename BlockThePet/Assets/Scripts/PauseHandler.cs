using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseHandler : MonoBehaviour
{
    private bool paused;
    public GameObject menuUI;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
                Resume();
            else
                Pause();
        }
        
    }
    public void Resume() {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        paused = false;
    }
    public void Pause() {
        Time.timeScale = 0f;
        menuUI.SetActive(true);
        paused = true;
    }
    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
