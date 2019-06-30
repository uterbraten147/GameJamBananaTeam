using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public int levelLoad;

    [SerializeField]
    private Image BarradeCarga;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "LoadScreenMainMenu")
        {
            StartCoroutine(cargarEscena());
        }
        else
        {
            StartCoroutine(showcutscene());
        }
        
    }

    IEnumerator showcutscene()
    {
        yield return new WaitForSeconds(6.5f);
        StartCoroutine(cargarEscena());
    }

    IEnumerator cargarEscena()
    {
        AsyncOperation cargarMundo = SceneManager.LoadSceneAsync(levelLoad);
        while (cargarMundo.progress < 1)
        {
            BarradeCarga.fillAmount = cargarMundo.progress;
            yield return new WaitForEndOfFrame();

        }
    }
}
