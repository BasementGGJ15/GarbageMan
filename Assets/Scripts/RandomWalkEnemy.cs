using UnityEngine;
using System.Collections;

public class RandomWalkEnemy : MonoBehaviour {

    public float Speed = 1.0f;
    public float TimeBetweenDirectionChange = 5.0f;
    public float GarbageDropTime = 10.0f;
    public GameObject GarbagePrefab;
    
    NavMeshAgent nav;
    GameManager gameManager;

    Vector3[] directions = 
    {   new Vector3(1,0,0), 
        new Vector3(-1,0,0), 
        new Vector3(0,0,1),
        new Vector3(0,0,-1)
    };

    float timer = 0.0f;
    float garbageTimer = 0.0f;
    Vector3 Destination;
	
	void Start () 
    {
        var gameController = GameObject.FindWithTag("GameController");
        gameManager = gameController.GetComponent<GameManager>();
        Destination = directions[0];
        timer = TimeBetweenDirectionChange;
        garbageTimer = 0.0f;
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        garbageTimer += Time.deltaTime;
        if (timer > TimeBetweenDirectionChange)
        {
            ChangeDestination();
        }
        if (garbageTimer > GarbageDropTime)
        {
            DropBomb();
        }
        nav.SetDestination(Destination);
	}

    void ChangeDestination()
    {
        timer = 0.0f;
        int randMin = 0;
        int randMax = directions.Length;
        int randomDirection = Random.Range(randMin, randMax);
        Destination = transform.position + (directions[randomDirection] * Speed);
    }

    void DropBomb()
    {
        garbageTimer = 0.0f;
        GameObject.Instantiate(GarbagePrefab, transform.position - Destination.normalized, Quaternion.identity);
        gameManager.AddGarbage();
    }
}
