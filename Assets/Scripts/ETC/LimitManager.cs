using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitManager : MonoBehaviour
{
    public static LimitManager instance;
    public float width, height;
    private float _radius = 1f;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 ApplyBounds(Vector3 pos, Boid boid)
    {
        if(pos.x > width)
        {
            pos.x = -width + _radius;
            boid.velocity.x = -boid.velocity.x;
            boid.velocity.y = -boid.velocity.y;
        }
            

        if (pos.x < -width)
        {
            pos.x = width - _radius;
            boid.velocity.x = -boid.velocity.x;
            boid.velocity.y = -boid.velocity.y;
        }

        if (pos.z > height)
        {
            pos.z = -height + _radius;
            boid.velocity.x = -boid.velocity.x;
            boid.velocity.y = -boid.velocity.y;
        }
            

        if (pos.z < -height)
        {
            pos.z = height - _radius;
            boid.velocity.x = -boid.velocity.x;
            boid.velocity.y = -boid.velocity.y;
        }

        return pos;
    }
}
