using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Hunter : MonoBehaviour
{
    //public Vector3 velocity;
    //public float maxVelocity, maxSpeed, maxEnergy = 20f, energy;

    //public Transform[] waypoints;

    //public int actualWaypoint;

    //private FSM _fsm;

    //private void Start()
    //{
    //    energy = maxEnergy;
    //    _fsm = new FSM();
    //    _fsm.CreateState(FSM.HunterStates.Idle, new Idle(_fsm, this));
    //    _fsm.CreateState(FSM.HunterStates.Patrol, new Patrol(_fsm, this));
    //    _fsm.CreateState(FSM.HunterStates.Chase, new Chase(_fsm, this));
    //    _fsm.ChangeState(FSM.HunterStates.Patrol);
    //}

    //protected void Update()
    //{
    //    _fsm.ArtificialUpdate();

    //    transform.position += velocity * Time.deltaTime;
    //    transform.forward = velocity;
    //}

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
