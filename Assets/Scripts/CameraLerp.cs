using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour {

    public Transform point1;
    public Transform point2;
    public float Smoothing = 0.01f;

    Vector3 LerpStep;
    Vector3 LerpStopPoint;
    bool lerpInProgress;
    float closeEnoughToEnd = 0.1f;
    void Start () 
    {
        //transform.position = new Vector3(point1.position.x, transform.position.y, point1.position.z);
        //LerpStopPoint = new Vector3(point2.position.x, transform.position.y, point2.position.z);
        //Vector3 LerpPoint = Vector3.Lerp(transform.position, LerpStopPoint, Smoothing);
        //LerpStep = LerpPoint - transform.position;
	}
	
	void Update () 
    {
	    if (Input.GetKey(KeyCode.T) && !lerpInProgress)
        {
            CalculateLerpStep();
            lerpInProgress = true;
            Debug.Log("Camera Move started");
        }
        if (lerpInProgress)
        {
            transform.position += LerpStep * Time.deltaTime;
            Vector3 difference = transform.position - LerpStopPoint;
            Debug.Log(string.Format("Different: {0}",difference.sqrMagnitude));
            if (difference.sqrMagnitude <= closeEnoughToEnd)
            {
                lerpInProgress = false;
                Debug.Log("Camera Move Ended");
            }       
        } 
	}

    void CalculateLerpStep()
    {
        transform.position = new Vector3(point1.position.x, transform.position.y, point1.position.z);
        LerpStopPoint = new Vector3(point2.position.x, transform.position.y, point2.position.z);
        Vector3 LerpPoint = Vector3.Lerp(transform.position, LerpStopPoint, Smoothing);
        LerpStep = LerpPoint - transform.position;
    }

}