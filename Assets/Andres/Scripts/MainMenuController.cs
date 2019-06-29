using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject CreditosPanel;

	// Use this for initialization
	void Awake () {

        MainPanel.SetActive(true);
        CreditosPanel.SetActive(false);

    }
	

    public void startGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Creditos()
    {
        MainPanel.SetActive(false);
        CreditosPanel.SetActive(true);
    }

    public void returnMenu()
    {
        MainPanel.SetActive(true);
        CreditosPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
