using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fleeAI : MonoBehaviour
{
    private NavMeshAgent mob;
    public GameObject Player;
    public float enemyDistance = 4.7f;
    // Start is called before the first frame update
    void Start()
    {
        mob = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < enemyDistance) {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPosition = transform.position + dirToPlayer;
            mob.SetDestination(newPosition);
        }
    }
}
