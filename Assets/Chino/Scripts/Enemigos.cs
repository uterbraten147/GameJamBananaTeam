﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour {

    Vector3 posiIni, direccion;
    public Transform rayorigin, player;
    Rigidbody mirig;

    public float speed=5.0f, distanciavista=14.0f;
    public Transform[] ruta;
    int current=0, sizeruta=0;
    bool alerta=false,checar = true, dircheck=true, esperar=false;

	void Start ()
    {
        posiIni = transform.position;
        mirig = GetComponent<Rigidbody>();
        //Saco vector de el enemigo al objetivo;
        direccion = ruta[current].position - posiIni;
        //Hago que sea valor 1
        direccion.Normalize();
        sizeruta=ruta.Length;
        //print("tamaño ruta es " + sizeruta);
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

            if (checar)
            {
                checar = false;
                StartCoroutine(ChecarPlayer(0.4f));
            }

            if (dircheck)
            {
                dircheck = false;
                StartCoroutine(Rechecardireccion());

            }
        }
        else
        {
            Persecucion();
        }

        if (!esperar)
        {
            Quaternion q = Quaternion.LookRotation(direccion);
            Quaternion p = Quaternion.Lerp(transform.rotation, q, 3f * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, p.eulerAngles.y, 0);
        }
        

    }

    private void FixedUpdate()
    {
        if (!esperar)
        {
            mirig.MovePosition(transform.position + direccion * Time.deltaTime * speed);
        }
        
    }

    public float Distancia(Vector3 A, Vector3 B)
    {
        float dist=0.0f;
        dist = ((A.x - B.x)*(A.x - B.x))+ ((A.z - B.z) * (A.z - B.z));
        dist = Mathf.Sqrt(dist);
        return dist;
    }

    public  IEnumerator ChecarPlayer(float t_)
    {
        yield return new WaitForSeconds(t_);
       
        if (Distancia(transform.position, player.position) < distanciavista){

            Vector3 directionplayer = (player.position - transform.position).normalized;
            float anguloentreestos = Vector3.Angle(transform.forward, directionplayer);
            if(anguloentreestos < 50f)
            {
                
                RaycastHit hit;
                if (Physics.Raycast(rayorigin.position,directionplayer, out hit, distanciavista))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.DrawLine(rayorigin.position, player.position, Color.red, 1f);
                        print("te vi putito");
                        alerta = true;
                    }
                }
            }
        }
        checar = true;
    }

    public IEnumerator Rechecardireccion()
    {
        yield return new WaitForSeconds(1f);
        direccion = ruta[current].position - transform.position;
        direccion.Normalize();
        dircheck = true;
    }

    public void Persecucion()
    {
        direccion = player.position - transform.position;
        direccion.Normalize();

        if(Distancia(transform.position, player.position)>distanciavista)
        {
            esperar = true;
            StartCoroutine(Esperar());
        }
    }

    public IEnumerator Esperar()
    {
        yield return new WaitForSeconds(1f);
        alerta = false;
        StartCoroutine(ChecarPlayer(0.0f));
        yield return new WaitForSeconds(0.1f);
        if (!alerta)
        {
            current = 0;
            direccion = ruta[0].position - transform.position;
            direccion.Normalize();
            esperar = false;
        }
        else { esperar = false; alerta = true; Persecucion(); }
        
    }
}
