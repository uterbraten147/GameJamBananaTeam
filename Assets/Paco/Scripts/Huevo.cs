using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huevo : MonoBehaviour {

    string GallineroName;
    public string[] id;
    GameController scpController;
    int score = 10;
    // Use this for initialization
    void Start () {
        scpController = GameObject.Find("GameManager").GetComponent<GameController>();
        GallineroName = transform.parent.name;
        id = GallineroName.Split('_');
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getId()
    {
        return id[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            scpController.SetScore(score);
            scpController.FeatherSpawner();
            scpController.EnDondePonerHuevo(getId());
            Destroy(gameObject);
        }
    }
}
