using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{
    public void OnEnter()
    {
        Debug.Log("Entramos a Patrol");
    }
    public void OnUpdate()

    {
        Debug.Log("Estamos en Patrol");
    }
    public void OnExit()
    {
        Debug.Log("Salimos del Patrol");
    }
}