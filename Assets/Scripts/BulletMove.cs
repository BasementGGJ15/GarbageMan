using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = transform.up * speed;
	}
}
