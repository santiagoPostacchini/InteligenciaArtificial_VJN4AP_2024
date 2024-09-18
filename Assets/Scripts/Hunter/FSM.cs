using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM 
{
  


    Dictionary<string, IState> _states = new Dictionary<string, IState>(); 

    IState _currentState;

      public void CreateState(string Idle, IState state)
        {
        if (!_states.ContainsKey(Idle)) 
       {
        _states.Add(Idle, state);
       }
    }

    public void ChangeState(string Idle)
    {
        if (_states.ContainsKey(Idle)) 
        {
            _currentState.OnExit();
            _currentState = _states[Idle];
            _currentState.OnEnter();
        }
       

    }
}
