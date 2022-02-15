using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState
    {
        patrol, 
        chase
    };

    public EnemyState curState = EnemyState.patrol;

    public float curMoveDirection;
    public float walkSpeed;
    public float runSpeed;

    public Transform[] flipChecks;
    public float flipCheckDistance = 0.2f;
    public LayerMask groundMask;

    private Rigidbody2D _rb;
    private bool _canFlip = true;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove(curMoveDirection * walkSpeed);
    }

    private void FixedUpdate()
    {
        foreach (var flipCheck in flipChecks)
        {
            Debug.DrawRay(flipCheck.position, Vector3.down * flipCheckDistance, Color.green, .1f);
            if (!Physics2D.Raycast(flipCheck.position, Vector2.down, flipCheckDistance, groundMask) && _canFlip)
            {
                curMoveDirection *= -1;
                StartCoroutine(SetCanFlip());
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
}
