using UnityEngine;
using System.Collections;

public class GarbageLobber : MonoBehaviour {

    public GameObject GarbagePrefab;
    public float TimeBetweenThrows = 3.0f;
    public float ThrowVelocity = 5.0f;
    float throwTimer = 0.0f;
    GameManager gameManager;
	// Use this for initialization
	void Start () 
    {
        throwTimer = 0.0f;
        var gameController = GameObject.FindWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        throwTimer += Time.deltaTime;
        if (throwTimer > TimeBetweenThrows)
        {
            throwTimer = 0.0f;
            Vector3 throwVector = new Vector3(-3.0f, 0.0f, Random.RandomRange(-3.0f, 3.0f));
            var newPieceOfGarbage = (GameObject)GameObject.Instantiate(GarbagePrefab, transform.position , Quaternion.identity);
            var body = newPieceOfGarbage.GetComponent<Rigidbody>();
            body.AddForce(throwVector);
            gameManager.AddGarbage();
        }
	}
}
