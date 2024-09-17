using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : IState
{
    public void OnEnter()
    {
        Debug.Log("Entramos a Chase");
    }
    public void OnUpdate()

    {
        Debug.Log("Estamos en Chase");
    }
    public void OnExit()
    {
        Debug.Log("Salimos del Chase");
    }
}
