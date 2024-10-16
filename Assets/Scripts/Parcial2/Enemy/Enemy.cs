using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity, maxSpeed;

    private FSM_E _fsm;

    Coroutine _MoveCoroutine;

    private void Start()
    {
        
        _fsm = new FSM_E();
        //_fsm.CreateState(FSM_E.EnemyStates.Chase, new S_EnemyChase(_fsm, this));
        //_fsm.CreateState(FSM_E.EnemyStates.Patrol, new S_EnemyPatrol(_fsm, this));
        //_fsm.CreateState(FSM_E.EnemyStates.Return, new S_EnemyReturn(_fsm, this));
        //_fsm.ChangeState(FSM_E.EnemyStates.Patrol);
    }

    protected void Update()
    {
        //_fsm.ArtificialUpdate();
        //transform.position += velocity * Time.deltaTime;
        //transform.forward = velocity;
    }

    public void SetPath(List<Node> path, Node _firstNode)
    {
        if(_MoveCoroutine != null)
        {
            StopCoroutine(_MoveCoroutine);
        }
        transform.position = _firstNode.transform.position;
        _MoveCoroutine = StartCoroutine(Move(path));
    }

    IEnumerator Move (List<Node> path)
    {
        while(path.Count > 0)
        {
            var dir = path[0].transform.position - transform.position;

            transform.position += dir.normalized * maxSpeed * Time.deltaTime;

            if (dir.magnitude <= 0.1f)
                path.RemoveAt(0);

            yield return null;
        }
        _MoveCoroutine = null;
    }

    //public bool CheckBoidNear(List<Boid> boidList, float radius)
    //{
    //    foreach (Boid boid in boidList)
    //    {
    //        if (Vector3.Distance(transform.position, boid.transform.position) < radius)
    //            return true;
    //    }

    //    return false;
    //}

    //public Boid GetNearestBoid(List<Boid> boidList, float radius)
    //{
    //    Boid nearest = null;

    //    foreach (var boid in boidList)
    //    {
    //        if (Vector3.Distance(transform.position, boid.transform.position) < radius || Vector3.Distance(transform.position, boid.transform.position) < Vector3.Distance(transform.position, nearest.transform.position))
    //        {
    //            nearest = boid;
    //        }
    //    }

    //    return nearest;
    //}

    //public int GetNearestWaypoint(Transform[] waypoints)
    //{
    //    Vector3 nearest = Vector3.positiveInfinity;
    //    int index = 0;
    //    int actualIndex = 0;

    //    foreach (Transform waypoint in waypoints)
    //    {
    //        if (Vector3.Distance(waypoint.position, transform.position) < Vector3.Distance(nearest, transform.position))
    //        {
    //            nearest = waypoint.transform.position;
    //            index = actualIndex;
    //        }
    //        actualIndex++;
    //    }

    //    return index;
    //}

    //public Vector3 Pursuit(Boid target)
    //{
    //    var posPre = target.transform.position + target.velocity;

    //    return Seek(posPre);
    //}

    //public Vector3 Seek(Vector3 target)
    //{
    //    Vector3 desired = target - transform.position;
    //    desired.Normalize();
    //    desired *= maxVelocity;

    //    Vector3 steering = desired - velocity;
    //    steering = Vector3.ClampMagnitude(steering, maxSpeed);

    //    return steering;
    //}

    //public void AddForce(Vector3 dir)
    //{
    //    velocity = Vector3.ClampMagnitude(velocity + dir, maxVelocity);
    //}

    //private void OnDrawGizmos()
    //{
    //    if (GameManager.Instance != null)
    //    {
    //        Gizmos.color = Color.magenta;
    //        Gizmos.DrawWireSphere(transform.position, GameManager.Instance.radiusDetect);
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawWireSphere(transform.position, GameManager.Instance.radiusSeparate);
    //    }
    //}
}
