using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    List<Node> _neighbours = new List<Node>();
    NodeGrid _grid;
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

            var nodeUp = _grid.GetNode(_x + 1, _y);
            if (nodeUp != null)
                _neighbours.Add(nodeUp);

            var nodeDown = _grid.GetNode(_x + 1, _y);
            if (nodeDown != null)
                _neighbours.Add(nodeDown);

            return _neighbours;
        }
    }
}
