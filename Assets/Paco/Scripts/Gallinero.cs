using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gallinero : MonoBehaviour {

    public GameObject EggPrefab;
    public bool TengoHuevo = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EggSpawner()
    {
        int QueGallinero;
        //QueGallinero = Random.Range(0, objGallinero.Length);
        GameObject aux;
        aux = Instantiate(EggPrefab, new Vector3(transform.position.x, transform.position.y+1, transform.position.z), Quaternion.identity);
        aux.transform.parent = gameObject.transform;
        TengoHuevo = true;


        /*for(int i = 0; i < objGallinero.Length; i++)
        {
            Instantiate(EggPrefab, new Vector3(objGallinero[QueGallinero].transform.position.x, objGallinero[i].transform.position.y + 5, objGallinero[i].transform.position.z), Quaternion.identity);
        }*/
    }
}
