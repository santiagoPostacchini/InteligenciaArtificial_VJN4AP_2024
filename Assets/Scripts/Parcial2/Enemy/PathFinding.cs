using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public void CalculateBFS(Node startingNode)
    {
        var frontier = new Queue<Node>();
        frontier.Enqueue(startingNode);

        var reached = new HashSet<Node>();
        reached.Add(startingNode);

        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();
            foreach (var node in current.GetNeighbours)
            {
                if (!reached.Contains(node))
                {
                    frontier.Enqueue(node);
                    reached.Add(node);
                }
            }
        }
    }
}
