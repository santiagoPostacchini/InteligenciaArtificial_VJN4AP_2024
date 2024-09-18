using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : IState
    {

   
        
        public void OnEnter()
        {
            Debug.Log("Entre a movement");
        }

        public void OnExit()
        {
            Debug.Log("sali de movement");
        }

        public void OnUpdate()
        {
            Debug.Log("estoy en movement");
        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }
    }
    }

