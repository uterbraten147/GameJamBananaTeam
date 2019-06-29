using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour {

    Vector3 posiIni, direccion;
    Rigidbody mirig;

    public float speed=5.0f;
    public Transform[] ruta;
    int current=0, sizeruta=0;
    bool alerta=false;

	void Start ()
    {
        posiIni = transform.position;
        mirig = GetComponent<Rigidbody>();
        //Saco vector de el enemigo al objetivo;
        direccion = ruta[current].position - posiIni;
        //Hago que sea valor 1
        direccion.Normalize();
        sizeruta=ruta.Length;
        print("tamaño ruta es" + sizeruta);
	}
	
	void Update ()
    {
        if (!alerta){
            if (Distancia(transform.position, ruta[current].position) < 1.0f)
            {
                current++;
                if (current >= sizeruta){ current = 0; }
                direccion = ruta[current].position - transform.position;
                direccion.Normalize();
            }
           
        }
        
        Quaternion q = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, 3f * Time.deltaTime);

        
    }

    private void FixedUpdate()
    {
        mirig.MovePosition(transform.position + direccion * Time.deltaTime * speed);     
    }

    public float Distancia(Vector3 A, Vector3 B)
    {
        float dist=0.0f;
        dist = ((A.x - B.x)*(A.x - B.x))+ ((A.z - B.z) * (A.z - B.z));
        dist = Mathf.Sqrt(dist);
        print(dist);
        return dist;
    }
}
