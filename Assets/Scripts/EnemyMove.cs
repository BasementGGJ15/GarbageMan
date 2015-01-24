using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
    }


    void Update()
    {
        nav.SetDestination(player.position);

    }
}
