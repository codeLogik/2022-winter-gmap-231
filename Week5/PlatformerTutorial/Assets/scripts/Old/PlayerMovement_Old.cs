using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Old : MonoBehaviour
{
    private Transform _respawnPoint;
    private PlatformController2D_Old _characterController;
    private float _movement = 0f;
    private bool _jump = false;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<PlatformController2D_Old>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle determining the movement based on input
        _movement = Input.GetAxis("Horizontal") * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button down");
        }

        // Determine if there is a jump that needs to happen.
        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            Debug.Log("Jump action performed");
            _jump = true;
        }
        else
        {
            _jump = false;
        }

        // Apply movement to the character controller
        _characterController.Move(_movement, _jump);
    }

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
