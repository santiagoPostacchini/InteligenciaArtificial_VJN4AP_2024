using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 _velocity;
    public float maxVelocity, maxSpeed;

    private FSM_E _fsm;

    Coroutine _MoveCoroutine;

    private void Start()
    {
        
        _fsm = new FSM_E();
    }

    protected void Update()
    {
        //_fsm.ArtificialUpdate();
        //transform.position += velocity * Time.deltaTime;
        //transform.forward = velocity;
    }

    public void SetPath(List<Node> path, Node _firstNode)
    {
        if(_MoveCoroutine != null)
        {
            StopCoroutine(_MoveCoroutine);
        }
        transform.position = _firstNode.transform.position;
        _MoveCoroutine = StartCoroutine(MoveTowardsPath(path));
    }

    IEnumerator MoveTowardsPath (List<Node> path)
    {
        while(path.Count > 0)
        {
            var dir = path[0].transform.position - transform.position;

            transform.position += dir.normalized * maxSpeed * Time.deltaTime;

            if (dir.magnitude <= 0.1f)
                path.RemoveAt(0);

            yield return null;
        }
        _MoveCoroutine = null;
    }
}
