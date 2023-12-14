using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;

    public float viewAngle = 90f; // Adjust the field of view angle
    public float viewDistance = 10f; // Adjust the field of view distance
    public LayerMask targetMask; // Define the layer where the player is
    public LayerMask obstacleMask; // Define the layer for obstacles (if needed)

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        // if (CanSeePlayer()) AwareOfPlayer = true;
        // else AwareOfPlayer = false;

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }

    // bool CanSeePlayer()
    // {

    //     Vector2 dirToTarget = _player.position - transform.position;
    //     float angle = Vector2.Angle(transform.right, dirToTarget);

    //     if (angle < viewAngle / 2)
    //     {
    //         float distanceToTarget = Vector2.Distance(transform.position, _player.position);
    //         if (!Physics2D.Raycast(transform.position, dirToTarget, distanceToTarget, obstacleMask))
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
