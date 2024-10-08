using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public enum HunterStates
    {
        Idle,
        Patrol,
        Chase
    }

    Dictionary<HunterStates, IState> _states = new Dictionary<HunterStates, IState>();

    IState _currentState;

    public void CreateState(HunterStates newState, IState state)
    {
        if (!_states.ContainsKey(newState))
        {
            _states.Add(newState, state);
        }
    }

    public void ChangeState(HunterStates state)
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
