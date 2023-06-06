using TMPro;
using UnityEngine;

namespace _Scripts
{
    [ExecuteAlways]
    public class CoordinateLabeler : MonoBehaviour
    {
        private TextMeshPro _label;
        private Vector2Int _coordinates = new Vector2Int();

        private void Awake()
        {
            _label = GetComponent<TextMeshPro>();
            DisplayCoordinates();
        }

        private void Update()
        {
            if (!Application.isPlaying)
            {
                DisplayCoordinates();
                UpdateObjectName();
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
        
    }
}
