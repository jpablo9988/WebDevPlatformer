using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //Using A* for 2D Pathfinding support.

// -- Based on a 2D Platformer Pathfinding tutorial: https://www.youtube.com/watch?v=sWqRfygpl4I
// -- Juan Pablo Amorocho . 301410163
//     -- It has been substantially modified to fit this project. -- 
public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding Attributes")]
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float pathUpdateSeconds = 0.5f;

    [Header("Pathfinding Physics")]

    [Tooltip("How far away to move to next node")]
    [SerializeField]
    private float nextWaypointDistance = 3f;
    [Tooltip("How vertical the node needs to be for this Agent to jump!")]
    [SerializeField]
    private float jumpNodeHeightRequirement = 0.8f;

    [Header("Custom Behavior")]
    [SerializeField]
    private bool followEnabled = true;
    [SerializeField]
    private bool jumpEnabled = true;
    [SerializeField]
    private bool directionLookEnabled = true;

    // --- PRIVATES --- //
    private bool foundTarget;
    private Path path;
    private Seeker seeker;
    private Rigidbody2D rb;
    private int currentWaypoint = 0;
    private bool lostTarget = false;
    private EnemyMovement _movement;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
         rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<EnemyMovement>();
        InvokeRepeating(nameof(UpdatePath), 0f, pathUpdateSeconds); //Over Update as Pathfinding is intensive. This repeats less.
    }

    public void FoundTarget(Transform target)
    {
        this.target = target;
        foundTarget = true;
    }
    public void LostTarget()
    {
        lostTarget = true;
    }
    private void FixedUpdate()
    {
        if (foundTarget && followEnabled)
        {
            PathFollow();
        }
    }

    private void UpdatePath()
    {
        if (followEnabled && foundTarget && seeker.IsDone())
        {
            // -- If the enemy has lost the target, don't generate another path. Stop generating paths.
            if (!lostTarget)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
            else
            {
                // -- Reset Variables -- //
                foundTarget = false;
                lostTarget = false;
                target = null;
            }
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }

        // Reached end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        // Direction Calculation
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        // Jump
        if ((direction.y > jumpNodeHeightRequirement) && jumpEnabled)
        {
            _movement.Jump();
        }

        // __Moves Enemy ___ //
        _movement.MoveToDirection(direction, true);

        // Next Waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        // Direction Graphics Handling
        if (directionLookEnabled)
        {
            _movement.SwitchDirection();
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}


