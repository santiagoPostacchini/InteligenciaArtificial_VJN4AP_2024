using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Boid : MonoBehaviour
{
    [SerializeField] float _maxVelocity;
    [SerializeField] float _maxSpeed;
    public P_Node firstNode;
    public Vector3 velocity;

    private void Start()
    {
        GameManager.Instance.boids.Add(this);
        AddForce(new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f)) * _maxVelocity);
    }

    void Update()
    {
        firstNode.Execute(this);
        transform.position = LimitManager.instance.ApplyBounds(transform.position + velocity * Time.deltaTime);
        transform.forward = velocity;
    }

    void AddForce(Vector3 dir)
    {
        velocity = Vector3.ClampMagnitude(velocity + dir, _maxVelocity);
    }

    public bool CheckFoodNear(List<Food> foods, float radius)
    {
        foreach (Food food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < radius)
                return true;
        }

        return false;
    }

    public bool CheckFlockNear(List<Boid> boids, float radius)
    {
        foreach (Boid boid in boids)
        {
            if (Vector3.Distance(transform.position, boid.transform.position) < radius)
                return true;
        }

        return false;
    }

    public bool CheckHunterNear(Hunter hunter, float radius)
    {
        if (Vector3.Distance(transform.position, hunter.transform.position) < radius)
            return true;

        return false;
    }

    public void Flocking()
    {
        AddForce(Alignment(GameManager.Instance.boids, GameManager.Instance.radiusDetect) * GameManager.Instance.weightAlignment);
        AddForce(Separate(GameManager.Instance.boids, GameManager.Instance.radiusSeparate) * GameManager.Instance.weightSeparation);
        AddForce(Cohesion(GameManager.Instance.boids, GameManager.Instance.radiusDetect) * GameManager.Instance.weightCohesion);
    }

    public void Arriving()
    {
        AddForce(Arrive(GetNearestFood(GameManager.Instance.foods, GameManager.Instance.radiusDetect)));
    }

    public void Evading()
    {
        AddForce(Evade(GameManager.Instance.hunter));
    }

    Vector3 Arrive(Vector3 target)
    {
        var desired = target - transform.position;

        float dist = desired.magnitude;

        if (dist > GameManager.Instance.radiusDetect)
            return Seek(target);

        desired.Normalize();
        desired *= _maxVelocity * (dist / GameManager.Instance.radiusDetect);

        var steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);

        return steering;
    }

    Vector3 GetNearestFood(List<Food> foods, float radius)
    {
        var nearest = Vector3.positiveInfinity;

        foreach (var food in foods)
        {
            if (Vector3.Distance(transform.position, food.transform.position) < radius || Vector3.Distance(transform.position, food.transform.position) < Vector3.Distance(transform.position, nearest))
            {
                nearest = food.transform.position;
            }
        }

        if (nearest == Vector3.positiveInfinity)
            return Vector3.zero;

        return nearest;
    }

    public Vector3 Evade(Hunter hunter)
    {
        var posPre = hunter.transform.position + hunter.velocity;

        return Flee(posPre);
    }

    Vector3 Flee(Vector3 target)
    {
        return -Seek(target);
    }

    public Vector3 Seek(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= _maxVelocity;

        Vector3 steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);

        return steering;
    }

    public void Die()
    {
        GameManager.Instance.boids.Remove(this);
        Destroy(this);
    }

    #region Flocking code
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

        var steering = desired - velocity;
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
            desired += boid.velocity;
            count++;
        }

        if (count == 0)
        {
            return Vector3.zero;
        }

        desired /= count;
        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - velocity;
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

        if (count == 0)
            return Vector3.zero;

        desired /= count;
        desired -= transform.position;

        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, _maxSpeed);

        return steering;
    }
    #endregion

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
