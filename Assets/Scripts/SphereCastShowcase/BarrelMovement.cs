using UnityEngine;

namespace SphereCastShowcase
{
    public class BarrelMovement : MonoBehaviour
    {
        [Tooltip("Units per second")]
        public float MovementSpeed = 0.1f;
        public Transform FinalPosition;
        private bool _isMoving = true;
        private Vector3 _movementStep;

        void Awake()
        {
            _movementStep =
                (FinalPosition.position - transform.position) *
                (MovementSpeed * Time.fixedDeltaTime);
        }

        void FixedUpdate()
        {
            BeginBarrelMovement();
        }

        private void BeginBarrelMovement()
        {
            if (_isMoving)
            {
                if (IsDistanceTooShort())
                {
                    _isMoving = false;
                }

                MoveBarrel();
            }
        }

        private bool IsDistanceTooShort()
        {
            Vector3 distanceBetweenPositions =
                FinalPosition.position - transform.position;

            return
                distanceBetweenPositions.magnitude < 0.01f;
        }

        private void MoveBarrel()
        {
            transform.position += _movementStep;
        }
    }
}
