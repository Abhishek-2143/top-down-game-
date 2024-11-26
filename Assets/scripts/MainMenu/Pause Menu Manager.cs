using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    private bool isGamePaued = false;

    public static PauseMenuManager Instance;
    public Button ResumeBotton;
    public Button QuitToMainMenuBotton;
    
    public GameObject PauseMenuCanvas;
   

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
        }
        PauseMenuCanvas.SetActive(false);

        ResumeBotton.onClick.AddListener(() => onResumeBottonPressed());

        QuitToMainMenuBotton.onClick.AddListener(() => onQuitToMainMenuBottonPressed());

        
    }
    
    public void onQuitToMainMenuBottonPressed()
    {
        SceneManager.LoadScene("MainMenu");
        isGamePaued = false;
        Time.timeScale = 1;
        PauseMenuCanvas.SetActive(false);
    }
    public void onResumeBottonPressed()
    {
        isGamePaued = false;
        Time.timeScale = 1;
        PauseMenuCanvas.SetActive(false);
    }
    public void ToggleGamePause()
    {
        if (isGamePaued==false)
        {
            
            isGamePaued = true;
            Time.timeScale = 0;
            PauseMenuCanvas.SetActive(true);
        }
        else
        {
            isGamePaued = false;
            Time.timeScale = 1;
            PauseMenuCanvas.SetActive(false);
        }
        
    }
   
}
