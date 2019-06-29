using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraColli : MonoBehaviour {

    //Variables
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    RaycastHit hit;
    public float distance;

    private void Awake()
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;

    }


	void Update () {
        Vector3 disiredCamaraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        

        if(Physics.Linecast (transform.parent.position, disiredCamaraPos))
        {
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);
	}

}
