using UnityEngine;
using System.Collections;

public class AreaTransition : MonoBehaviour {

    public GameManager gameManager;
    public Transform[] areas = new Transform[2];


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.TransitionArea(areas);             
        }
    }
}
