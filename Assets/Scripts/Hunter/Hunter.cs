using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Vector3 velocity;

    private FSM _fsm;

    private void Start()
    {
        _fsm = new FSM();
        _fsm.CreateState(FSM.HunterStates.Idle, new Idle(_fsm));
        _fsm.CreateState(FSM.HunterStates.Patrol, new Patrol(_fsm));
        _fsm.CreateState(FSM.HunterStates.Chase, new Chase(_fsm));

        _fsm.ChangeState(FSM.HunterStates.Patrol);

    }

    void Update()
    {
        _fsm.ArtificialUpdate();
    }
}
