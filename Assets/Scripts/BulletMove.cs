using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	public float speed;
	
	void Start ()
	{
		rigidbody2D.velocity = transform.up * speed;
	}
}
