using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuUI;
    private bool paused;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(paused){
                Resume();
            }
            else{
                Pause();
            }
            
        }
    }

    public void Resume(){
        menuUI.SetActive(false);
    }

    public void Pause(){
        menuUI.SetActive(true);
    }
}
