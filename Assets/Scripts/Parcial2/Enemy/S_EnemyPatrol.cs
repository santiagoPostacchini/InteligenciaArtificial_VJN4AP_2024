using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyPatrol : IState
{
    private FSM_E _fsm;
    private Enemy _enemy;

    public S_EnemyPatrol(FSM_E fsm, Enemy enemy)
    {
        _fsm = fsm;
        _enemy = enemy;
    }

    public void OnEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
