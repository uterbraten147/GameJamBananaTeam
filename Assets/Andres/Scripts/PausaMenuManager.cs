using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenuManager : MonoBehaviour {

    bool menuPausa = false;
    public GameObject PausaMenuPanel;

	// Use this for initialization
	void Awake ()
    {
        PausaMenuPanel.SetActive(false);
		

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!menuPausa)
            {
                PausaMenuPanel.SetActive(true);
                menuPausa = true;
                Time.timeScale = 0;              
            }
        }
	}

    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void reanudar()
    {
        Time.timeScale = 1;
        PausaMenuPanel.SetActive(false);
        menuPausa = false;   
    }
}
