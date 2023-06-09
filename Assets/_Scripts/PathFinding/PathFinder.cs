using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class PathFinder : MonoBehaviour
    {

        [SerializeField] private Vector2Int startCoordinates;
        [SerializeField] private Vector2Int destinationCoordinates;

        private Node _startNode;
        private Node _destinationNode;
        private Node _currentSearchNode;

        private Queue<Node> _frontier = new Queue<Node>();
        
        private Dictionary<Vector2Int, Node> _reached = new Dictionary<Vector2Int, Node>();
        

        private Vector2Int[] _directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };

        private GridManager _gridManager;

        private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();


        private void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
            if (_gridManager != null)
            {
                _grid = _gridManager.Grid;
            }

            
            
        }

        void Start()
        {
            _startNode = _gridManager.Grid[startCoordinates];
            _destinationNode = _gridManager.Grid[destinationCoordinates];
            
            BreadthFirstSearch();
            BuildPath();
        }

        private void ExploreNeighbors()
        {
            List<Node> neighbors = new List<Node>();

            foreach (var direction in _directions)
            {
                Vector2Int neighborCoords = _currentSearchNode.coordinates + direction;

                if (_grid.ContainsKey(neighborCoords))
                {
                    neighbors.Add(_grid[neighborCoords]);
                    
                    
                }
            }

            foreach (Node neighbor in neighbors)
            {
                if (!_reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
                {
                    neighbor.connectedTo = _currentSearchNode;
                    _reached.Add(neighbor.coordinates,neighbor);
                    _frontier.Enqueue(neighbor);
                }
            }

        }


        private void BreadthFirstSearch()
        {
            bool isRunning = true;
            
            _frontier.Enqueue(_startNode);
            _reached.Add(startCoordinates,_startNode);

            while (_frontier.Count > 0 && isRunning == true)
            {
                _currentSearchNode = _frontier.Dequeue();
                _currentSearchNode.isExplored = true;
                ExploreNeighbors();
                if (_currentSearchNode.coordinates == destinationCoordinates)
                {
                    isRunning = false;
                }
            }
        }

        List<Node> BuildPath()
        {
            List<Node> path = new List<Node>();

            Node currentNode = _destinationNode;
            
            path.Add(currentNode);
            
            currentNode.isPath = true;

            while (currentNode.connectedTo != null)
            {
                currentNode = currentNode.connectedTo;
                path.Add(currentNode);
                currentNode.isPath = true;
            }
            path.Reverse();
            return path;
        }
    }
}
