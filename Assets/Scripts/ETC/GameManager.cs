using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<Boid> boids = new List<Boid>();
    public List<Food> foods = new List<Food>();
    public Hunter hunter;
    public float radiusDetect;
    public float radiusSeparate;

    [Range(0, 1)]
    public float weightAlignment;
    [Range(0, 1)]
    public float weightSeparation;
    [Range(0, 1)]
    public float weightCohesion;

    private void Awake()
    {
        Instance = this;
    }
}
