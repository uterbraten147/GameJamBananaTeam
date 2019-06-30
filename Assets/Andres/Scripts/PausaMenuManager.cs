using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PausaMenuManager : MonoBehaviour {

    bool menuPausa = false;
    public GameObject PausaMenuPanel;
    public GameObject eventSys;
    public GameObject BTNPause;
    GameObject player;
    // Use this for initialization
    void Awake ()
    {
        PausaMenuPanel.SetActive(false);
        Time.timeScale = 1;
        //player = GameObject.Find("Player").GetComponent<CharacterMov>();
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<CharacterMov>().enabled = true;


    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Escape)||Input.GetButton("Start")) && !HUD.muertisimo ){
            if (!menuPausa)
            {
                player.GetComponent<CharacterMov>().enabled = false;

                eventSys.GetComponent<EventSystem>().SetSelectedGameObject(BTNPause, null);
                PausaMenuPanel.SetActive(true);
                menuPausa = true;
                Time.timeScale = 0;              
            }
        }
	}

    public void returnMainMenu()
    {
        SceneManager.LoadScene(3);
    }



    public void reiniciar()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void reanudar()
    {
        Time.timeScale = 1;
        player.GetComponent<CharacterMov>().enabled = true;
        PausaMenuPanel.SetActive(false);
        menuPausa = false;   
    }
}
