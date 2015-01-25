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
    //public List<GameObject> Area1Doors;

    public CameraLerp cameraLerp;

    Dictionary<string, Area> areaTagToInt; 

	// Use this for initialization
	void Start () {
        //get doors
        
        areaTagToInt = new Dictionary<string, Area>()
        {
            { "Area1", new Area() {Id = 1,Location =  areas[0], Name = "Area1", startingGarbage = 2, maxGarbage = 6, spawners = GameObject.FindGameObjectsWithTag("Area1Spawner")}},
            { "Area2", new Area() {Id = 2,Location =  areas[1], Name = "Area2", startingGarbage = 2, maxGarbage = 6, spawners = GameObject.FindGameObjectsWithTag("Area2Spawner") }},
            { "Area3", new Area() {Id = 3,Location =  areas[2], Name = "Area3", startingGarbage = 2, maxGarbage = 6, spawners = GameObject.FindGameObjectsWithTag("Area3Spawner") }},
            { "Area4", new Area() {Id = 4,Location =  areas[3], Name = "Area4", startingGarbage = 2, maxGarbage = 6, spawners = GameObject.FindGameObjectsWithTag("Area4Spawner") }},
            { "Area5", new Area() {Id = 5,Location =  areas[4], Name = "Area5", startingGarbage = 2, maxGarbage = 6, spawners = GameObject.FindGameObjectsWithTag("Area5Spawner") }}
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
            //Do Game Over
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
            cameraLerp.StartLerping(neighbours[0], neighbours[1]);
            Area area;
            areaTagToInt.TryGetValue(neighbours[1].gameObject.tag, out area);
            currentArea = area.Id;
            SetMaxGarbage(area.maxGarbage);
            garbageAmount = area.startingGarbage;
            garbageMeter.value = garbageAmount;
            foreach (GameObject spawner in area.spawners)
            {
                spawner.GetComponent<MonsterSpawner>().spawnsEnabled = true;
            }
        }
        else
        {
            cameraLerp.StartLerping(neighbours[1], neighbours[0]);
            Area area;
            areaTagToInt.TryGetValue(neighbours[0].gameObject.tag, out area);
            currentArea = area.Id;
            SetMaxGarbage(area.maxGarbage);
            garbageAmount = area.startingGarbage;
            garbageMeter.value = garbageAmount;
            foreach (GameObject spawner in area.spawners)
            {
                spawner.GetComponent<MonsterSpawner>().spawnsEnabled = true;
            }
        }
    }
}
