using UnityEngine;

namespace VectorArithmeticShowcase
{
    public class ConstantMovmentAlongNormal : MonoBehaviour
    {
        public Vector3 directionOfMovement;
        [Tooltip("Units per minute")]
        public float speedOfMovement;
    
        void Update()
        {
            MoveAlongPassedVector();
            FaceMovementDirection();
        }

        private void MoveAlongPassedVector()
        {
            transform.position +=
                directionOfMovement.normalized *
                speedOfMovement * 
                Time.deltaTime / 
                60.0f;
        }

        private void FaceMovementDirection()
        {
            transform.forward =
                directionOfMovement.normalized;
        }
    }
}
