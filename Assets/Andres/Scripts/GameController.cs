using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public int FeatherCounter = 0;
    public GameObject prefabFeather, spawnerPlace;
    private float time=0;
    [SerializeField] private Text temporizador;
    [SerializeField] public int mainTimer;

	// Use this for initialization
	void Start () {
        time = mainTimer;
        for(int i = 0; i <= FeatherCounter; i++)
        {
            FeatherSpawner();
        }
        //StartCoroutine("loseTime");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(time >= 0.0f)
        {
            time -= Time.deltaTime;
            //temporizador.text = "Tiempo: " +time.ToString();
        }
        else
        {
            //StopCoroutine("loseTime");
            //temporizador.text = "se acabo el tiempo";
        }
		
	}

    public int getScore()
    {
        return score;
    }

    public float getTime()
    {
        return time;
    }

    public bool GameOver()
    {
        if(time <= 0)
        {

            return true;

        }
        else
        {
            return false;
        }
    }

    void FeatherSpawner()
    {
        GameObject aux;
        aux= Instantiate(prefabFeather, new Vector3(spawnerPlace.transform.position.x, spawnerPlace.transform.position.y, spawnerPlace.transform.position.z), Quaternion.identity);
        aux.transform.rotation = Quaternion.Euler(180, 90, 0);
    }

    IEnumerator loseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time-= Time.deltaTime;
        }

    }


}
