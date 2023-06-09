using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private Vector2Int gridSize;
        private Dictionary<Vector2Int, Node> _grid = new Dictionary<Vector2Int, Node>();

        public Dictionary<Vector2Int, Node> Grid
        {
            get { return _grid; }
        }
        private void Awake()
        {
            CreateGrid();
        }

        public Node GetNode(Vector2Int coordinates)
        {
            if (_grid.ContainsKey(coordinates))
            {
                return _grid[coordinates];
            }

            return null;
        }

        private void CreateGrid()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    Vector2Int coordinates = new Vector2Int(x, y);
                    _grid.Add(coordinates,new Node(coordinates, true));
                    
                    // Debug.Log(grid[coordinates].coordinates + " = " + grid[coordinates].isWalkable);
                }
            }
        }
    }
}
