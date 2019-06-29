using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMov : MonoBehaviour {

    int cont = 0;

    public float InputX;
    public float InputZ;
    public Animator anim;
    public float Speed;
    public int velPlayer;

    public float smoothRotation;
    private Vector3 moveVector;
    public Rigidbody rb;
    public int limites;



	// Use this for initialization
	void Start () {

        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void Update () {
        InputMagnitud();


       
    }

    
    void InputMagnitud()
    {
        InputX = Mathf.Clamp(10, 0, Input.GetAxis("Horizontal"));
        InputZ = Input.GetAxis("Vertical");
        InputZ = Mathf.Clamp(InputZ, 0f, 1f);
        

        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2.0f);
        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2.0f);


         rb.MovePosition(transform.position + transform.forward * Time.deltaTime* InputZ* velPlayer);

        if (InputX != 0)
        {
            transform.Rotate(Vector3.up, InputX * smoothRotation);
           


        }
        else
        {
           
        }


        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        anim.SetFloat("InputMagnitud", Speed, 0.0f, Time.deltaTime);



    }

    public int GetPuntuacion()
    {
        return cont;
    }
}
