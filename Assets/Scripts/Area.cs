using UnityEngine;
using System.Collections;

[System.Serializable]
public class Area  
{
    public Transform Location;
    public string Name;
    public int Id;

    //public GameObject[] doors;
    public GameObject[] spawners;

    public int startingGarbage;
    public int maxGarbage;
}
