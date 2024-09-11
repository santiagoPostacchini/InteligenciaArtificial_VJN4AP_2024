using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private float _radius = 1f;

    private void Start()
    {
        GameManager.Instance.foods.Add(this);
        
    }

    private void Update()
    {
        foreach(Boid boid in GameManager.Instance.boids)
        {
            if (Vector3.Distance(boid.transform.position, transform.position) < _radius)
            {
                GameManager.Instance.foods.Remove(this);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (GameManager.Instance != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }

}
