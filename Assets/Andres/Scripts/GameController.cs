using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static int score = 0;
    public int FeatherCounter = 0;
    public GameObject FeatherPrefab, SpawnerPoint, EggPrefab;
    GameObject[] objGallinero;
    public static bool ponercola = false;
    private float time=0;
    public int QueGallinero;
    [SerializeField] public int mainTimer;

	// Use this for initialization
	void Start () {
        objGallinero = GameObject.FindGameObjectsWithTag("Gallinero");
        time = mainTimer;
        //Debug.Log(objGallinero.Length);
        EnDondePonerHuevo("0");
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

    public void SetScore(int _score)
    {
        score += _score;
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

    public void EnDondePonerHuevo(string id)
    {
        
        QueGallinero = Random.Range(0, objGallinero.Length);

        if(objGallinero[QueGallinero].GetComponent<Gallinero>().TengoHuevo == false || objGallinero[QueGallinero].name != "Gallinero_"+id)
        {
            objGallinero[QueGallinero].GetComponent<Gallinero>().EggSpawner();
        }
        else
        {
            EnDondePonerHuevo(id);
        }
       
    }

    public void FeatherSpawner()
    {
        GameObject aux;
        aux = Instantiate(FeatherPrefab,new Vector3(SpawnerPoint.transform.position.x, SpawnerPoint.transform.position.y, SpawnerPoint.transform.position.z), Quaternion.identity);
        aux.transform.rotation = Quaternion.Euler(Random.Range(170,280), 0, Random.Range(0, 10));
        aux.transform.parent = SpawnerPoint.transform;
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
