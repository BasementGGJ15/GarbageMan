using UnityEngine;
using System.Collections;

public class DoorCloser : MonoBehaviour {

    public GameObject[] Doors;

    DoorActivator[] activators;

	void Start () {
	    if (Doors.Length >= 0)
        {
            activators = new DoorActivator[Doors.Length];
            for (int i=0; i<Doors.Length; i++)
            {
                activators[i] = Doors[i].GetComponent<DoorActivator>();
            }
        }
        else
        {
            activators = new DoorActivator[0];
        }
	}
	
	void OnTriggerEnter (Collider other) {
        if (other.tag == "Player")
        {
            Debug.Log("Close doors!");
            foreach (DoorActivator activator in activators)
            {
                activator.CloseDoor();
            }
        }
	
	}
}
