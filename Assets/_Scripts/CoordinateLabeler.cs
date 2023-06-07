using TMPro;
using UnityEngine;

namespace _Scripts
{
    [ExecuteAlways]
    public class CoordinateLabeler : MonoBehaviour
    {

        [SerializeField] private Color defaultColor = Color.white;
        [SerializeField] private Color blockedColor = Color.gray;
        
        private TextMeshPro _label;
        private Vector2Int _coordinates = new Vector2Int();
        private WayPoint _wayPoint;

        private void Awake()
        {
            
            _wayPoint = GetComponentInParent<WayPoint>();
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
            }

            ColorCoordinates();
            ToggleLabels();
        }

        private void ColorCoordinates()
        {
            if (_wayPoint.IsPlaceable)
            {
                _label.color = defaultColor;
            }
            else
            {
                _label.color = blockedColor;
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
