using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button StartButton;
    public Button QuitButton;

    private void Awake()
    {

        StartButton.onClick.AddListener(() => onStartButtonPressed());
        QuitButton.onClick.AddListener(() => onQuitButtonPressed());

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onStartButtonPressed()
    {
        SceneManager.LoadScene("Level01");
    }

    public void onQuitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quit Worked");
    }

}
