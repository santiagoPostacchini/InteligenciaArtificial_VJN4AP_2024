using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : IState
{
    private FSM _fsm;
    public Chase(FSM fsm)
    {
        _fsm = fsm;
    }
    public void OnEnter()
    {
        Debug.Log("Entramos a Chase");
    }
    public void OnUpdate()

    {
        Debug.Log("Estamos en Chase");
    }
    public void OnExit()
    {
        Debug.Log("Salimos del Chase");
    }
}
