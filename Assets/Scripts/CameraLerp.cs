﻿using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour {

    //public Transform point1;
    //public Transform point2;
    public float Smoothing = 0.01f;

    Vector3 LerpStep;
    Vector3 LerpStopPoint;
    bool lerpInProgress;
    float previousMagSqrToTarget = float.MaxValue;
    float closeEnoughToEnd = 0.01f;
	
	void Update () 
    {
        if (lerpInProgress)
        {
            transform.position += LerpStep * Time.deltaTime;
            Vector3 difference =  LerpStopPoint - transform.position;
            if (difference.sqrMagnitude < previousMagSqrToTarget)
            {
                previousMagSqrToTarget = difference.sqrMagnitude;
            }
            else
            {
                lerpInProgress = false;
                previousMagSqrToTarget = float.MaxValue;
            }
            if (difference.sqrMagnitude <= closeEnoughToEnd)
            {
                lerpInProgress = false;
                previousMagSqrToTarget = float.MaxValue;
            }       
        } 
	}

    void CalculateLerpStep(Transform point1, Transform point2)
    {
        transform.position = new Vector3(point1.position.x, transform.position.y, point1.position.z);
        LerpStopPoint = new Vector3(point2.position.x, transform.position.y, point2.position.z);
        Vector3 LerpPoint = Vector3.Lerp(transform.position, LerpStopPoint, Smoothing);
        LerpStep = LerpPoint - transform.position;
    }

    public void StartLerping(Transform point1, Transform point2)
    {
        CalculateLerpStep(point1, point2);
        lerpInProgress = true;
    }

}