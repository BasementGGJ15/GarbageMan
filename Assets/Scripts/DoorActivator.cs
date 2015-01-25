using UnityEngine;
using System.Collections;

public class DoorActivator : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetTrigger("OpenDoor");
    }

    public void CloseDoor()
    {
        anim.SetTrigger("CloseDoor");
    }
}
