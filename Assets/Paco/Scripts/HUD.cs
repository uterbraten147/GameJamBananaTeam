﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    // Use this for initialization
    GameObject goPanel;
    Image timer;
    Text txtScore, txtStart;
    bool isStart = false;
    public float cont;
    CharacterMov scpCharacter;
    GameController scpManager;
    void Start() {
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();
        txtScore = GameObject.FindGameObjectWithTag("txtCounter").GetComponent<Text>();
        txtStart = GameObject.Find("txtStart").GetComponent<Text>();
        goPanel = GameObject.Find("PanelCanvas");
        goPanel.SetActive(false);
       scpCharacter = GameObject.Find("Player").GetComponent<CharacterMov>();
        scpManager = GameObject.Find("GameManager").GetComponent<GameController>();
        txtScore.text = "0x";
        StartCoroutine(Counter());
    }
	
	// Update is called once per frame
	void Update () {


        if (isStart)
        
        {
            
            txtScore.text = scpManager.getScore().ToString() + "x";
            timer.fillAmount = (scpManager.getTime() / scpManager.mainTimer);
                                  //20/20 = 1
                                  //19/20 = .95
                                                     
        
           /* cont = Time.deltaTime / 10;
            timer.fillAmount -= cont;*/

            if (scpManager.GameOver())
            {

                goPanel.SetActive(true);
                goPanel.transform.GetChild(0).GetComponent<Text>().text = "Score: " + scpManager.getScore().ToString();
            }
        }


    }

    IEnumerator Counter()
    {
        txtStart.text = "3";
        yield return new WaitForSeconds(.5f);
        txtStart.text = "2";
        yield return new WaitForSeconds(.5f);
        txtStart.text = "1";
        yield return new WaitForSeconds(.5f);
        txtStart.text = "Go!";
        yield return new WaitForSeconds(.2f);
        txtStart.text = "";
        yield return new WaitForSeconds(.1f);
        isStart = true;

    }
}
