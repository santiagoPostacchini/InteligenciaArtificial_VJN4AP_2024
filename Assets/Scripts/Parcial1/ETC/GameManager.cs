using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Parcial1
    //public List<Boid> boids = new List<Boid>();
    //public List<Food> foods = new List<Food>();
    //public Hunter hunter;
    //public float radiusDetect;
    //public float radiusSeparate;

    //[Range(0, 1)]
    //public float weightAlignment;
    //[Range(0, 1)]
    //public float weightSeparation;
    //[Range(0, 1)]
    //public float weightCohesion;
    #endregion

    public static GameManager Instance;
    private Node _startingNode, _goalNode;
    public PathFinding pathFinding;
    public Enemy enemy;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_startingNode == null || _goalNode == null) return;
            enemy.SetPath(pathFinding.CalculateBFS(_startingNode, _goalNode), _startingNode);
        }
    }

    public void SetStartingNode(Node node)
    {
        var cond = _startingNode != null;

        Material _mat = _startingNode.gameObject.GetComponent<Renderer>().material;

        _mat.color = cond ? Color.green : Color.white;

        _goalNode = node;
    }
    
    public void SetGoalNode(Node node)
    {
        SetNode(_startingNode, node, Color.cyan);
    }

    private void SetNode(Node nodeToAssign, Node node, Color color)
    {
        var cond = _goalNode != null;

        Material _mat = _startingNode.gameObject.GetComponent<Renderer>().material;

        _mat.color = cond ? Color.cyan : Color.white;

        _goalNode = node;
    }
}
