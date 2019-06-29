using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public int FeatherCounter = 0;
    public GameObject FeatherPrefab, SpawnerPoint;
    public static bool ponercola = false;

    private float time=0;
   
    [SerializeField] public int mainTimer;

	// Use this for initialization
	void Start () {
        time = mainTimer;
      /*  for(int i = 0;i < FeatherCounter; i++)
        {
            FeatherSpawner();
        }*/
        //StartCoroutine("loseTime");
		
	}
	
	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
        if (time >= 0.0f)
        {
            time -= Time.deltaTime;
            //temporizador.text = "Tiempo: " +time.ToString();
        }
        else
        {
            //StopCoroutine("loseTime");
            //temporizador.text = "se acabo el tiempo";
        }

        if (Score.EntroalNido)
        {
            ponercola = true;
        }
        else
        {
            ponercola = false;
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
        aux = Instantiate(FeatherPrefab,new Vector3(SpawnerPoint.transform.position.x, SpawnerPoint.transform.position.y, SpawnerPoint.transform.position.z), Quaternion.identity);
        aux.transform.rotation = Quaternion.Euler(Random.Range(170,280), 0, Random.Range(0, 10));
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
