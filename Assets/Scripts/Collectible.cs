using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour {

    public PickUp pickUpTarget;

    Renderer child;

    void Awake()
    {
        child = GetComponentInChildren<SpriteRenderer>();
    }
    

	void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Occured");
        if (other.gameObject.tag == "Player")
        {
            pickUpTarget.Get();
            child.enabled = false;
            GameObject.Destroy(this.gameObject, 1.0f);
        }
    }
}
