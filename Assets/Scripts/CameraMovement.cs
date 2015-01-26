using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float CameraSpeed = 1.0f;

    IEnumerator MoveObject(Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    Vector3 CalculateCameraDestinationAboveScene(Transform point1, Transform point2)
    {
        return new Vector3(point2.position.x, transform.position.y, point2.position.z);
    }

    public void InitiateCameraMove(Transform point1, Transform point2)
    {
        Vector3 Start = transform.position;
        Vector3 Destination = CalculateCameraDestinationAboveScene(point1, point2);

        StartCoroutine(MoveObject(Start, Destination, CameraSpeed));
    }
}