using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField] float _maxVelocity;
    [SerializeField] float _maxSpeed;
    Vector3 _velocity;

    private void Start()
    {
        GameManager.Instance.boids.Add(this);
    }

    void Update()
    {
        //Flocking(); (primer nodo)
        transform.position = LimitManager.instance.ApplyBounds(transform.position + _velocity * Time.deltaTime);
        transform.forward = _velocity;
    }

    void AddForce(Vector3 dir)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + dir, _maxVelocity);
    }

    void Flocking()
    {
        AddForce(Alignment(GameManager.Instance.boids, GameManager.Instance.radiusDetect) * GameManager.Instance.weightAlignment);
        AddForce(Separate(GameManager.Instance.boids, GameManager.Instance.radiusSeparate) * GameManager.Instance.weightSeparation);
        AddForce(Cohesion(GameManager.Instance.boids, GameManager.Instance.radiusDetect) * GameManager.Instance.weightCohesion);
    }

    Vector3 Separate(List<Boid> boids, float radius)
    {
        Vector3 desired = Vector3.zero;

        foreach (Boid boid in boids)
        {
            var dir = transform.position - boid.transform.position;

            if (dir.magnitude > radius || boid == this)
                continue;

            desired += dir;
        }

        if (desired == Vector3.zero)
            return desired;

        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);

        return steering;
    }
    
    Vector3 Alignment(List<Boid> boids, float radius)
    {
        Vector3 desired = Vector3.zero;
        int count = 0;

        foreach (Boid boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) > radius || boid == this)
            {
                continue;
            }
            desired += boid._velocity;
            count++;
        }

        if(count == 0)
        {
            return Vector3.zero;
        }

        desired /= count;
        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);
        return steering;
    }
    
    Vector3 Cohesion(List<Boid> boids, float radius) //mismo radio que alineacion
    {
        var desired = transform.position;
        int count = 0;

        foreach (Boid boid in boids) 
        {
            if (Vector3.Distance(transform.position, boid.transform.position) > radius || boid == this)
            {
                continue;
            }
            desired += boid.transform.position;
            count++;
        }

        if(count == 0)
            return Vector3.zero;

        desired /= count;
        desired -= transform.position;
        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);

        return steering;
    }

    //void Seek()

    //void Evade()

    private void OnDrawGizmos()
    {
        if(GameManager.Instance != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, GameManager.Instance.radiusDetect);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, GameManager.Instance.radiusSeparate);
        }
    }
}
