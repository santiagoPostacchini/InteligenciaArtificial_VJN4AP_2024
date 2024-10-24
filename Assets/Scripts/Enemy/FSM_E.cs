using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_E
{
    public enum EnemyStates
    {
        Return,
        Patrol,
        Chase
    }

    Dictionary<EnemyStates, IState> _states = new Dictionary<EnemyStates, IState>();

    IState _currentState;

    public void CreateState(EnemyStates newState, IState state)
    {
        if (!_states.ContainsKey(newState))
        {
            _states.Add(newState, state);
        }
    }

    public void ChangeState(EnemyStates state)
    {
        if (_states.ContainsKey(state))
        {
            if(_currentState != null)
            {
                Debug.Log("entre");
                _currentState.OnExit();
                _currentState = _states[state];
                _currentState.OnEnter();
            }
            else
            {
                _currentState = _states[state];
                _currentState.OnEnter();
            }
            
        }

    }

    public void ArtificialUpdate()
    {
        if (_currentState != null)
        {
            _currentState.OnUpdate();
        }
    }
}
