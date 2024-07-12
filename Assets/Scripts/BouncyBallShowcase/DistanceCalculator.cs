using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class DistanceCalculator : MonoBehaviour
    {
        public TextMeshProUGUI OutputDistance;
        private bool _isPossibleToFindDistance = true;
        private float _distanceToFloor = 0;
        private SphereCollider _spCollider;

        void Awake()
        {
            _spCollider = GetComponent<SphereCollider>();
        }

        void Update()
        {
            CalculateDistanceToFloor();
            OutputDistanceToCanvas();
        }

        private void CalculateDistanceToFloor()
        {
            Vector3 raycastStartPosition = CalculateRayStartPoint();

            Ray rayToFloor = 
                new Ray(raycastStartPosition, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(rayToFloor, out hit))
            {
                _isPossibleToFindDistance = true;
                _distanceToFloor = hit.distance;
            }
            else
            {
                _isPossibleToFindDistance = false;
                _distanceToFloor = -1;
            }
        }

        private Vector3 CalculateRayStartPoint()
        {
            return
                transform.position +
                Vector3.down * _spCollider.radius;
        }
        
        private void OutputDistanceToCanvas()
        {
            if (_isPossibleToFindDistance)
            {
                OutputDistance.text = _distanceToFloor.ToString("0.00");
            }
            else
            {
                OutputDistance.text = "unknown";
            }
        }
    }
}
