using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{

    string currentState = "Idle";

    public Vector3 velocity;

    FSM _fsm;

    private void Start()
    {
        _fsm = new FSM();
    }

    void Update()
    {
        
    }
}
