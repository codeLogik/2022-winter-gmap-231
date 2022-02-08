using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRespawn : MonoBehaviour
{
    private Transform _lastRespawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deathPlane")
        {
            transform.position = _lastRespawnPoint.position;
        }

        if (collision.gameObject.tag == "Respawn")
        {
            _lastRespawnPoint = collision.gameObject.transform;
        }
    }
}
