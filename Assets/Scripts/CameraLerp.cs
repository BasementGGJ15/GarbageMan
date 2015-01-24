using UnityEngine;
using System.Collections;

public class CameraLerp : MonoBehaviour {

    public Transform point1;
    public Transform point2;
    public float Smoothing = 0.01f;

    Vector3 LerpStep;
    Vector3 LerpStopPoint;
    bool lerpInProgress;
    float closeEnoughToEnd = 1.0f;
    void Start () 
    {
        transform.position = new Vector3(point1.position.x, point1.position.y, transform.position.z);
        LerpStep = Vector3.Lerp(transform.position, point2.position, Smoothing);
        LerpStopPoint = new Vector3(point2.position.x, point2.position.y, transform.position.z);
	}
	
	void Update () 
    {
	    if (Input.GetKey(KeyCode.T) && !lerpInProgress)
        {
            lerpInProgress = true;
            Debug.Log("Camera Move started");
        }
        if (lerpInProgress)
        {
            transform.position += LerpStep * Time.deltaTime;
            Vector2 difference = transform.position - LerpStopPoint;
            if (difference.sqrMagnitude <= closeEnoughToEnd)
            {
                lerpInProgress = false;
                Debug.Log("Camera Move Ended");
            }       
        } 
	}
}