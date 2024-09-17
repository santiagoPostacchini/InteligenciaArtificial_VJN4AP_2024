using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM 
{
    Dictionary<string, IState> _states = new Dictionary<string, IState>(); 


    IState _currentState;

    public void CreateState(string name, IState state)
    {
        if (!_states.ContainsKey(name)) 
        {
            _states.Add(name, state);
        }

        
    }
}
