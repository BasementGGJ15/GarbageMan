﻿using UnityEngine;
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
    //public List<GameObject> Area1Doors;

    public CameraMovement cameraMovement;

    Dictionary<string, Area> areaTagToInt; 

	// Use this for initialization
	void Start () {
        //get doors
        
        areaTagToInt = new Dictionary<string, Area>()
        {
            { "Area1", new Area() {Id = 1,Location =  areas[0], Name = "Area1", startingGarbage = 4, maxGarbage = 20, spawners = GameObject.FindGameObjectsWithTag("Area1Spawner")}},
            { "Area2", new Area() {Id = 2,Location =  areas[1], Name = "Area2", startingGarbage = 18, maxGarbage = 20, spawners = GameObject.FindGameObjectsWithTag("Area2Spawner") }},
            { "Area3", new Area() {Id = 3,Location =  areas[2], Name = "Area3", startingGarbage = 8, maxGarbage = 15, spawners = GameObject.FindGameObjectsWithTag("Area3Spawner") }},
            { "Area4", new Area() {Id = 4,Location =  areas[3], Name = "Area4", startingGarbage = 14, maxGarbage = 20, spawners = GameObject.FindGameObjectsWithTag("Area4Spawner") }},
            { "Area5", new Area() {Id = 5,Location =  areas[4], Name = "Area5", startingGarbage = 4, maxGarbage = 20, spawners = GameObject.FindGameObjectsWithTag("Area5Spawner") }}
        };
        
        garbageMeter.maxValue = maxGarbageForCurrentLevel;
        garbageMeter.value = garbageAmount;
        //Doors = new Dictionary<int, List<GameObject>>();
        //Doors.Add(1, Area1Doors);
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().DieFromMeter();
        }
    }

    public void RemoveGarbage()
    {
        garbageAmount--;
        garbageMeter.value = garbageAmount;
        if (garbageAmount == 0)
        {
            foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
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
            Area areaFrom;
            areaTagToInt.TryGetValue(neighbours[0].gameObject.tag, out areaFrom);
            areaFrom.startingGarbage = 0;
            cameraMovement.InitiateCameraMove(neighbours[0], neighbours[1]);
            Area areaTo;
            areaTagToInt.TryGetValue(neighbours[1].gameObject.tag, out areaTo);
            currentArea = areaTo.Id;
            SetMaxGarbage(areaTo.maxGarbage);
            garbageAmount = areaTo.startingGarbage;
            garbageMeter.value = garbageAmount;
            foreach (GameObject spawner in areaTo.spawners)
            {
                if (spawner != null)
                {
                    spawner.GetComponent<MonsterSpawner>().spawnsEnabled = true;
                }
            }
            if (garbageAmount > 0)
            {
                foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
                {
                    DoorActivator da = door.GetComponent<DoorActivator>();
                    da.CloseDoor();
                }
            }
        }
        else
        {
            Area areaFrom;
            areaTagToInt.TryGetValue(neighbours[1].gameObject.tag, out areaFrom);
            areaFrom.startingGarbage = 0;
            cameraMovement.InitiateCameraMove(neighbours[1], neighbours[0]);
            Area areaTo;
            areaTagToInt.TryGetValue(neighbours[0].gameObject.tag, out areaTo);
            currentArea = areaTo.Id;
            SetMaxGarbage(areaTo.maxGarbage);
            garbageAmount = areaTo.startingGarbage;
            garbageMeter.value = garbageAmount;
            foreach (GameObject spawner in areaTo.spawners)
            {
                if (spawner != null)
                {
                    spawner.GetComponent<MonsterSpawner>().spawnsEnabled = true;
                }
            }
            if (garbageAmount > 0)
            {
                foreach (GameObject door in GameObject.FindGameObjectsWithTag("Door"))
                {
                    DoorActivator da = door.GetComponent<DoorActivator>();
                    da.CloseDoor();
                }
            }
        }
    }
}
