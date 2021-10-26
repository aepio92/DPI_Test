using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Handler : MonoBehaviour
{
    private bool GameOver = false;

    [SerializeField] private GameObject GameOverPanel;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (GameOver == false)
        {
            CheckOverState();
        }
    }

    void CheckOverState()
    {
        int AiCount = GameObject.FindGameObjectsWithTag("AI").Length; //getting the count of all the ai in the level

        if(AiCount<=0)
        {
            if (GameOverPanel != null)
            {
                GameOverPanel.SetActive(true);
                GameOver = true;
            }
        }
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
