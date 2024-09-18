using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Hunter : MonoBehaviour
{
    public Vector3 velocity;
    public float maxVelocity, maxSpeed, energy = 20f;

    private FSM _fsm;

    private void Start()
    {
        _fsm = new FSM();
        _fsm.CreateState(FSM.HunterStates.Idle, new Idle(_fsm, this));
        _fsm.CreateState(FSM.HunterStates.Patrol, new Patrol(_fsm, this));
        _fsm.CreateState(FSM.HunterStates.Chase, new Chase(_fsm, this));
        _fsm.ChangeState(FSM.HunterStates.Patrol);

    }

    void Update()
    {
        _fsm.ArtificialUpdate();
    }

    public bool CheckBoidNear(List<Boid> boids, float radius)
    {
        foreach (Boid boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < radius)
                return true;
        }

        return false;
    }

    public Boid GetNearestBoid(List<Boid> boids, float radius)
    {
        foreach (var boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < radius || Vector3.Distance(transform.position, boid.transform.position) < Vector3.Distance(transform.position, nearest.transform.position))
            {
                var nearest = boid;
            }
        }

        return nearest;
    }

    Vector3 Pursuit(Boid target)
    {
        var posPre = target.transform.position + target.velocity;

        return Seek(posPre);
    }

    Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxVelocity;

        Vector3 steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, maxSpeed);

        return steering;
    }
}
