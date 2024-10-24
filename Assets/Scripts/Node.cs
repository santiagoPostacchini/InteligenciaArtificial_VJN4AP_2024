using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    List<Node> _neighbours = new List<Node>();
    NodeGrid _grid;
    public bool blocked = false;
    public int Cost = 1;
    private int _x, _y;

    public void Initialize(NodeGrid grid, int x, int y)
    {
        _grid = grid;
        _x = x;
        _y = y;
    }

    public List<Node> GetNeighbours
    {
        get 
        {
            if(_neighbours.Count > 0)
                return _neighbours;
            
            var nodeLeft = _grid.GetNode(_x - 1, _y);
            if (nodeLeft != null)
                _neighbours.Add(nodeLeft);

            var nodeRight = _grid.GetNode(_x + 1, _y);
            if (nodeRight != null)
                _neighbours.Add(nodeRight);

            var nodeUp = _grid.GetNode(_x, _y + 1);
            if (nodeUp != null)
                _neighbours.Add(nodeUp);

            var nodeDown = _grid.GetNode(_x, _y - 1);
            if (nodeDown != null)
                _neighbours.Add(nodeDown);

            return _neighbours;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.SetStartingNode(this);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.SetGoalNode(this);
        }

        if (Input.GetMouseButtonDown(2))
        {
            blocked = !blocked;

            var color = blocked ? Color.red : Color.white;

            GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
