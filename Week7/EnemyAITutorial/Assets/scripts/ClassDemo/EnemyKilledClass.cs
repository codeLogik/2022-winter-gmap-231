using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledClass : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(enemy);
        }
    }
}
