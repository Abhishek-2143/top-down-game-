using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuManager : MonoBehaviour
{
    private float Death;
    public Button RetuenToMainMenuButton;
    public Button RestartButton;
    public GameObject DeathMenuCanvas;
   

    private void Awake()
    {
        Death = GetComponent<HealthAndDamage>().GetHealthRatio();
        DeathMenuCanvas.SetActive(false);
    }
   
    public void OnPlayerDeath()
    {  
        if (Death==0)
        {
            Time.timeScale = 0;
            DeathMenuCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
        }


    }
    public void onReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void onRestart()
    {
        Time.timeScale = 1;
    }
}
