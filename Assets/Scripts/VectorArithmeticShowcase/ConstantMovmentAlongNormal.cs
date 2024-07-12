using UnityEngine;

namespace VectorArithmeticShowcase
{
    public class ConstantMovmentAlongNormal : MonoBehaviour
    {
        public Vector3 DirectionOfMovement;
        [Tooltip("Units per minute")]
        public float SpeedOfMovement;
    
        void Update()
        {
            MoveAlongPassedVector();
            FaceMovementDirection();
        }

        private void MoveAlongPassedVector()
        {
            transform.position +=
                DirectionOfMovement.normalized *
                SpeedOfMovement * 
                Time.deltaTime / 
                60.0f;
        }

        private void FaceMovementDirection()
        {
            transform.forward =
                DirectionOfMovement.normalized;
        }
    }
}
