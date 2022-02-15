using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIClass : MonoBehaviour
{
    public enum EnemyState
    {
        patrol, 
        chase
    };

    public EnemyState curState = EnemyState.patrol;

    public float currMoveDirection;
    public float walkSpeed;
    public float runSpeed;

    public Color patrolColor;
    public Color chaseColor;

    public Transform[] flipChecks;
    public float flipCheckDistance = 0.2f;
    public LayerMask groundMask;

    private Rigidbody2D _rb;
    private bool _canFlip = true;
    private GameObject _player;
    private MeshRenderer _meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.color = patrolColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (curState == EnemyState.patrol)
        {
            EnemyMove(walkSpeed * currMoveDirection);
        }
        else if (curState == EnemyState.chase)
        {
            float directionToPlayer = transform.position.x - _player.transform.position.x;
            if (directionToPlayer < 0 && currMoveDirection != 1)
            {
                Flip();
            }
            else if (directionToPlayer > 0 && currMoveDirection != -1)
            {
                Flip();
            }

            EnemyMove(runSpeed * currMoveDirection);
        }
    }

    private void FixedUpdate()
    {
        if (curState == EnemyState.patrol)
        {
            foreach (var flipCheck in flipChecks)
            {
                Debug.DrawRay(flipCheck.position, Vector3.down * flipCheckDistance, Color.green, .1f);
                if (!Physics2D.Raycast(flipCheck.position, Vector2.down, flipCheckDistance, groundMask) && _canFlip)
                {
                    Flip();
                }
            }
        }
    }

    public void EnemyMove(float move)
    {
        _rb.velocity = new Vector2(move, _rb.velocity.y);
    }

    private IEnumerator SetCanFlip()
    {
        _canFlip = false;
        yield return new WaitForSeconds(0.3f);
        _canFlip = true;
    }

    private void Flip()
    {
        currMoveDirection *= -1;
        StartCoroutine(SetCanFlip());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            curState = EnemyState.chase;
            _player = collision.gameObject;
            _meshRenderer.material.color = chaseColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            curState = EnemyState.patrol;
            _player = null;
            _meshRenderer.material.color = patrolColor;
        }
    }
}
