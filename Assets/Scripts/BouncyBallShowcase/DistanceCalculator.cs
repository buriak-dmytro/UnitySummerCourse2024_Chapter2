using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class DistanceCalculator : MonoBehaviour
    {
        public TextMeshProUGUI outputDistance;
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
            Physics.Raycast(rayToFloor, out hit);

            distanceToFloor = hit.distance;
        }

        private Vector3 CalculateRayStartPoint()
        {
            return
                transform.position +
                Vector3.down * spCollider.radius;
        }
        
        private void OutputDistanceToCanvas()
        {
            outputDistance.text = distanceToFloor.ToString("0.00");
        }
    }
}
