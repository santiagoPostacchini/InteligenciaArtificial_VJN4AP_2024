using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFOV : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float _radius;
    [SerializeField] private float _angle;

    private void Update()
    {
        if(InView(target)) 
            GetComponent<MeshRenderer>().material.color = Color.red;
        else
            GetComponent<MeshRenderer>().material.color = Color.white;
    }

    bool InView(Transform target)
    {
        var dir = target.position - transform.position;

        if (dir.magnitude <= _radius)
        {
            if (Vector3.Angle(transform.forward, dir) <= _angle * 0.5f)
                if(GameManager.Instance.InLineOfSight(transform.position, dir))
                    return true;

        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, _radius);

        Gizmos.color = Color.red;

        Vector3 LineA = GetVectorFromAngle(_angle * 0.5f + transform.eulerAngles.y);
        Vector3 LineB = GetVectorFromAngle(-_angle * 0.5f + transform.eulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + LineA * _radius);
        Gizmos.DrawLine(transform.position, transform.position + LineB * _radius);
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
