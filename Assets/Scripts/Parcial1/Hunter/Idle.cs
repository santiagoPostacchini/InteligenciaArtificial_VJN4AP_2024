using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle //: IState
{
    //private FSM _fsm;
    //private Hunter _hunter;

    //public Idle(FSM fsm, Hunter hunter)
    //{
    //    _fsm = fsm;
    //    _hunter = hunter;
    //}

    //public void OnEnter()
    //{
    //    Debug.Log("Entramos a Idle");
    //}

    //public void OnUpdate()
    //{
    //    Debug.Log("Estamos en Idle");
    //    if(_hunter.CheckBoidNear(GameManager.Instance.boids, GameManager.Instance.radiusDetect) && _hunter.energy > 10f)
    //    {
    //        _fsm.ChangeState(FSM.HunterStates.Chase);
    //    }
    //    _hunter.energy += 2f * Time.deltaTime;
    //    if(_hunter.energy >= _hunter.maxEnergy)
    //    {
    //        _fsm.ChangeState(FSM.HunterStates.Patrol);
    //    }
    //}

    //public void OnExit()
    //{
    //    Debug.Log("Salimos del Idle");
    //}
}
