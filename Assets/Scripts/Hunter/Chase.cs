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
        _hunter.GetNearestBoid(GameManager.Instance.boids, GameManager.Instance.radiusDetect);
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
