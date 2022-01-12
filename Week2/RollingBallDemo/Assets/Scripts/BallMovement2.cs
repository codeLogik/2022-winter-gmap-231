using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement2 : MonoBehaviour
{
    public enum CollisionBehavior
    {
        bounce,
        reset
    }

    public float moveSpeed;
    public float minSpeed;
    public float maxSpeed;
    public CollisionBehavior collisionBehavior;
    public Text ballSpeedText;

    private GameObject ball;
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        ball = this.gameObject;
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        ballSpeedText.text = moveSpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // ball.transform.position += ball.transform.forward * moveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        ball.transform.position += ball.transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball" || collision.gameObject.tag == "wall")
        {
            if (collisionBehavior == CollisionBehavior.bounce)
            {
                ContactPoint contactPoint = collision.contacts[0];
                ball.transform.forward = Vector3.Reflect(ball.transform.forward, contactPoint.normal);
            }
            else
            {
                ball.transform.position = startPosition;
                ball.transform.rotation = startRotation;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        ballSpeedText.text = moveSpeed.ToString();
    }
}
