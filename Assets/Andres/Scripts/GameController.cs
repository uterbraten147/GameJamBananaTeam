using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public Canvas canvas1;

    private int time=0;
    [SerializeField] private Text temporizador;
    [SerializeField] private int mainTimer;

	// Use this for initialization
	void Start () {
        time = mainTimer;
        StartCoroutine("loseTime");
		
	}
	
	// Update is called once per frame
	void Update () {

        if(time >= 0.0f)
        {
            //time -= Time.deltaTime;
            temporizador.text = "Tiempo: " +time.ToString();
        }
        else
        {
            StopCoroutine("loseTime");
            temporizador.text = "se acabo el tiempo";
        }
		
	}

    public int getScore()
    {
        return score;
    }

    public int getTime()
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


    IEnumerator loseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time--;
        }

    }


}
