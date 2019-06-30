using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject CreditosPanel;
    public GameObject eventSys;
    public GameObject BTNCredit;
    public GameObject BTNMenu;

	// Use this for initialization
	void Awake () {


        Time.timeScale = 1;
        MainPanel.SetActive(true);
        CreditosPanel.SetActive(false);
        

    }
	

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Creditos()
    {
        eventSys.GetComponent<EventSystem>().SetSelectedGameObject(BTNCredit,null);
        MainPanel.SetActive(false);
        CreditosPanel.SetActive(true);
    }

    public void returnMenu()
    {
        eventSys.GetComponent<EventSystem>().SetSelectedGameObject(BTNMenu,null);
        MainPanel.SetActive(true);
        CreditosPanel.SetActive(false);
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
