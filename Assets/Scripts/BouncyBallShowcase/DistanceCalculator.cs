using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class DistanceCalculator : MonoBehaviour
    {
        public TextMeshProUGUI outputDistance;
        private bool isPossibleToFindDistance = true;
        private float distanceToFloor = 0;
        private SphereCollider spCollider;

        void Awake()
        {
            spCollider = GetComponent<SphereCollider>();
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
                isPossibleToFindDistance = true;
                distanceToFloor = hit.distance;
            }
            else
            {
                isPossibleToFindDistance = false;
                distanceToFloor = -1;
            }
        }

        private Vector3 CalculateRayStartPoint()
        {
            return
                transform.position +
                Vector3.down * spCollider.radius;
        }
        
        private void OutputDistanceToCanvas()
        {
            if (isPossibleToFindDistance)
            {
                outputDistance.text = distanceToFloor.ToString("0.00");
            }
            else
            {
                outputDistance.text = "unknown";
            }
        }
    }
}
