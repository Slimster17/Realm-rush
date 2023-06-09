using TMPro;
using UnityEngine;

namespace _Scripts
{
    [ExecuteAlways]
    [RequireComponent(typeof(TextMeshPro))]
    public class CoordinateLabeler : MonoBehaviour
    {

        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color blockedColor = Color.gray;
        
        [SerializeField] private Color exploredColor = Color.yellow;
        [SerializeField] private Color pathColor = new Color(1f,0.5f,0f);
        
        private TextMeshPro _label;
        private Vector2Int _coordinates = new Vector2Int();

        private GridManager _gridManager;
       

        private void Awake()
        {
            _gridManager = FindObjectOfType<GridManager>();
            
            _label = GetComponent<TextMeshPro>();
            _label.enabled = false;
            DisplayCoordinates();
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                DisplayCoordinates();
                UpdateObjectName();
                _label.enabled = true;
            }

            SetLabelColor();
            ToggleLabels();
        }

        private void SetLabelColor()
        {
            if (_gridManager == null)
            {
                return;
            }

            Node node = _gridManager.GetNode(_coordinates);

            if (node == null)
            {
                return;
            }

            if (!node.isWalkable)
            {
                _label.color = blockedColor;
            }
            else if (node.isPath)
            {
                _label.color = pathColor;
                
            }
            else if (node.isExplored)
            {
                _label.color = exploredColor;
            }
            else
            {
                _label.color = defaultColor;
            }
        }

        private void DisplayCoordinates()
        {
            var position = transform.parent.position;
            
            _coordinates.x = Mathf.RoundToInt(position.x / UnityEditor.EditorSnapSettings.move.x);
            _coordinates.y = Mathf.RoundToInt(position.z / UnityEditor.EditorSnapSettings.move.z);
            
            _label.text = $"{_coordinates.x}, {_coordinates.y}";
        }

        private void UpdateObjectName()
        {
            transform.parent.name = _coordinates.ToString();
        }

        private void ToggleLabels()
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                _label.enabled = !_label.IsActive();
            }
        }
        
    }
}
