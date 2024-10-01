using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Chase : IState
{
    private FSM _fsm;
    private Hunter _hunter;

    public Chase(FSM fsm, Hunter hunter)
    {
        _fsm = fsm;
        _hunter = hunter;
    }

    public void OnEnter()
    {
        Debug.Log("Entramos a Chase");
    }

    public void OnUpdate()
    {
        Debug.Log("Estamos en Chase");

        var nearestBoid = _hunter.GetNearestBoid(GameManager.Instance.boids, GameManager.Instance.radiusDetect);

        _hunter.AddForce(_hunter.Pursuit(nearestBoid));

        if (_hunter.energy <= 0)
        {
            _fsm.ChangeState(FSM.HunterStates.Idle);
        }
        _hunter.energy -= 2f * Time.deltaTime;
        if (Vector3.Distance(_hunter.transform.position, nearestBoid.transform.position) < GameManager.Instance.radiusSeparate / 2)
        {
            nearestBoid.Die();
        }
    }

    public void OnExit()
    {
        Debug.Log("Salimos del Chase");
        _hunter.energy = 0;
    }
}
