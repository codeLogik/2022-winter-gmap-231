using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemoNavMeshAI : MonoBehaviour
{
    public enum EnemyState
    {
        patrol,
        chase
    }

    public EnemyState currentEnemyState = EnemyState.patrol;

    public Transform[] wayPoints;
    public int currentWaypoint = 0;

    private NavMeshAgent _agent;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = wayPoints[currentWaypoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyState == EnemyState.patrol)
        {
            if (!_agent.pathPending && _agent.remainingDistance < .5f)
            {
                ChangeWaypoint();
            }
        }
        else if (currentEnemyState == EnemyState.chase)
        {
            // Need to keep setting the destination to be the position of the player.
            _agent.destination = _player.transform.position;
        }
    }

    public void ChangeWaypoint()
    {
        if (currentWaypoint < wayPoints.Length - 1)
        {
            currentWaypoint++;
        }
        else
        {
            currentWaypoint = 0;
        }

        _agent.destination = wayPoints[currentWaypoint].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = other.gameObject;
            currentEnemyState = EnemyState.chase;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player = null;
            currentEnemyState = EnemyState.patrol;
            _agent.destination = wayPoints[currentWaypoint].position;
        }
    }
}
