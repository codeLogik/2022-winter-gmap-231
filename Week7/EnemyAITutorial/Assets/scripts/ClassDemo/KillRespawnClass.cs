using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRespawnClass : MonoBehaviour
{
    private Transform _lastRespawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "deathPlane")
        {
            Respawn();
        }

        if (collision.gameObject.tag == "Respawn")
        {
            _lastRespawnPoint = collision.gameObject.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        transform.position = _lastRespawnPoint.position;
    }
}
