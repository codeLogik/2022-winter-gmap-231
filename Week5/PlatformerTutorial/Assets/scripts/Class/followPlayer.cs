using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float zOffset;
    public float cameraDelay = .2f;

    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, zOffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, cameraDelay);
    }
}
