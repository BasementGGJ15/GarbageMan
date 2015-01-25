using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int garbageAmount;
    public int maxGarbageForCurrentLevel;
    public Slider garbageMeter;

    public int currentArea = 1;
    public Dictionary<int, List<GameObject>> Doors;
    public List<GameObject> Area1Doors;

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
}
