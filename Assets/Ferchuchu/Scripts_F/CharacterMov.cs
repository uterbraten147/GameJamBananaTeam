using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMov : MonoBehaviour {

    int cont = 0;

    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;
    private float VerticalVel;
    private Vector3 moveVector;



	// Use this for initialization
	void Start () {

        anim = this.GetComponent<Animator>();
        cam = Camera.main;
        controller = this.GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        InputMagnitud();

       

        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            VerticalVel -= 0;
        }
        else
        {
            VerticalVel -= 2;
        }
        moveVector = new Vector3(0, VerticalVel,0);
        controller.Move(moveVector);
	}

    void PlayerMoveAnrotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camara = Camera.main;
        var forward = cam.transform.forward;
        var rigth = cam.transform.right;

        forward.y = 0.0f;
        rigth.Normalize();

        desiredMoveDirection = forward * InputZ + rigth * InputX;
        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }
    }

    void InputMagnitud()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        anim.SetFloat("InputZ", InputZ, 0.0f, Time.deltaTime * 2.0f);
        anim.SetFloat("InputX", InputX, 0.0f, Time.deltaTime * 2.0f);


        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        if(Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitud", Speed, 0.0f, Time.deltaTime);
            PlayerMoveAnrotation();
        }
        else if(Speed < allowPlayerRotation){
            anim.SetFloat("InputMagnitud", Speed, 0.0f, Time.deltaTime);

        }


    }

    public int GetPuntuacion()
    {
        return cont;
    }
}
