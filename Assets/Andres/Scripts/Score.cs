using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static bool EntroalNido = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (EntroalNido)
        {
            GameController.score += 50;
            EntroalNido = false;
        }
		
	}

    private void OnTriggerEnter(Collider nido)
    {
        if (nido.gameObject.CompareTag("Player"))
        {
            EntroalNido = true;
        }
        
    }
}
