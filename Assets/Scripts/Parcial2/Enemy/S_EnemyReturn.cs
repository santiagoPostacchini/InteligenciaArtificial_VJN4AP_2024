using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyReturn : IState
{
    private FSM_E _fsm;
    private Enemy _enemy;

    public S_EnemyReturn(FSM_E fsm, Enemy enemy) 
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
