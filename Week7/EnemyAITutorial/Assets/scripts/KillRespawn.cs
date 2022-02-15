using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRespawn : MonoBehaviour
{
    private Transform _respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "deathPlane")
        {
            transform.position = _respawnPoint.position;
        }

        if (collision.transform.tag == "Respawn")
        {
            _respawnPoint = collision.gameObject.transform;
        }
    }
}
