using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Vector3 velocity;

    FSM _fsm;

    private void Start()
    {
        _fsm = new FSM();
        _fsm.CreateState("Idle", new Idle());
        _fsm.CreateState("Movement", new Movement());
        _fsm.CreateState("Patrol", new Patrol());
        _fsm.CreateState("Chase", new Chase());

        _fsm.ChangeState("Idle");

    }

    void Update()
    {
        
    }
}
