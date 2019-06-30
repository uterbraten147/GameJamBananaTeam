using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour {


    ///Variables
    public float CamaraMovSpeed = 120.0f;
    public GameObject CamaraFollowObj;
    Vector3 FollowPos;
    public float clampAngle = 80.0f;
    public float inputSensivity = 150.0f;
    public GameObject CamaraObj;
    public GameObject PlayerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    private float rotY = 0.0f;
    private float rotX = 0.0f;


    void Start () {
        //CamaraObj = Camera.main;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;



    }
	
	void Update () {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;
        Debug.Log(finalInputZ);

        rotY += finalInputX * inputSensivity * Time.deltaTime;
        rotX += finalInputZ * inputSensivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, 40);
        //rotY = Mathf.Clamp(rotY, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX*-1, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    private void LateUpdate()
    {
        CamaraUpdater();
    }

    void CamaraUpdater()
    {
        Transform target = CamaraFollowObj.transform;

        float step = CamaraMovSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position ,step);
    }
}
