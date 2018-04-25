﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject hudUI;
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!GamePaused){
                Pause();
            }
        }
	}

    public void Resume() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        hudUI.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        hudUI.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void LoadMenu(int sceneIndex){
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
        GamePaused = false;
    }

    public void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
