using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IState
{

    public void OnEnter()
    {
        Debug.Log("Entramos a Idle");
    }
    public void OnUpdate()

    {
        Debug.Log("Estamos en Idle");
    }
    public void OnExit()
    {
        Debug.Log("Salimos del Idle");
    }
}
