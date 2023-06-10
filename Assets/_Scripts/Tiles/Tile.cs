using System;
using UnityEngine;

namespace _Scripts
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private Tower towerPrefab;
       
        [SerializeField] private bool isPlaceable;
        public bool IsPlaceable => isPlaceable;

        private GridManager _gridManager;
        private PathFinder _pathFinder;

        private Vector2Int _coordinates = new Vector2Int();

        private void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
            _pathFinder = FindObjectOfType<PathFinder>();
        }

        private void Start()
        {
            if (_gridManager != null)
            {
                _coordinates = _gridManager.GetCoordinatesFromPosition(transform.position);
                
            }

            if (!isPlaceable)
            {
                _gridManager.BlockNode(_coordinates);
            }
        }

        private void OnMouseDown()
        {
            if (_gridManager.GetNode(_coordinates).isWalkable && !_pathFinder.WillBlockPath(_coordinates))
            {
                Debug.Log(transform.name);
                bool isPlaced =  towerPrefab.CreateTower(towerPrefab,transform.position);
                isPlaceable = isPlaced;
                _gridManager.BlockNode(_coordinates);
            }
     
        }
    }
}
