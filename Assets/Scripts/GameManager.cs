using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int garbageAmount;
    public int maxGarbageForCurrentLevel;
    public Slider garbageMeter;

    public int currentArea = 1;
    public Transform[] areas;

    public Dictionary<int, List<GameObject>> Doors;
    public List<GameObject> Area1Doors;

    public CameraLerp cameraLerp;

	// Use this for initialization
	void Start () {
        garbageMeter.maxValue = maxGarbageForCurrentLevel;
        garbageMeter.value = garbageAmount;
        Doors = new Dictionary<int, List<GameObject>>();
        Doors.Add(1, Area1Doors);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetMaxGarbage(int value)
    {
        maxGarbageForCurrentLevel = value;
        garbageMeter.maxValue = maxGarbageForCurrentLevel; 
    }

    public void AddGarbage()
    {
        garbageAmount++;
        garbageMeter.value = garbageAmount;
        if (garbageAmount == maxGarbageForCurrentLevel)
        {
            Debug.Log("YOU DED!");
            //Do Game Over
        }
    }

    public void RemoveGarbage()
    {
        garbageAmount--;
        garbageMeter.value = garbageAmount;
        if (garbageAmount == 0)
        {
            foreach (GameObject door in Area1Doors)
            {
                DoorActivator da = door.GetComponent<DoorActivator>();
                da.OpenDoor();
            }
        }
    }

    public void TransitionArea(Transform[] neighbours)
    {
        if (areas[currentArea-1].transform.position == neighbours[0].transform.position)
        {
            cameraLerp.StartLerping(neighbours[0], neighbours[1]);
            currentArea = 2;
        }
        else
        {
            cameraLerp.StartLerping(neighbours[1], neighbours[0]);
            currentArea = 1;
        }
    }
}
