using UnityEngine;

namespace RaycastsShowcase
{
    public class TurretBrain : MonoBehaviour
    {
        public UserInputProcessing UserInput;
        public Transform DebugLineStartPosition;
        private Vector3 _lookAtPosition;
        private bool _isLaserEnabled = false;

        void Awake()
        {
            _lookAtPosition = transform.position;
        }

        void OnEnable()
        {
            UserInput.LookAtPosition += OnLookAtPosition;
            UserInput.LaserEnable += OnLaserEnable;
        }

        void Update()
        {
            if (_isLaserEnabled)
            {
                DrawDebugLine();
            }
        }

        void OnDisable()
        {
            UserInput.LookAtPosition -= OnLookAtPosition;
            UserInput.LaserEnable -= OnLaserEnable;
        }

        private void OnLookAtPosition(Vector3 positionToLookAt)
        {
            StoreLookAtPosition(positionToLookAt);
            AdjustLookAtDirection();
        }

        private void StoreLookAtPosition(Vector3 positionToLookAt)
        {
            _lookAtPosition = positionToLookAt;
        }

        private void AdjustLookAtDirection()
        {
            transform.up = (_lookAtPosition - transform.position).normalized;
        }

        private void OnLaserEnable(bool laserEnablingStatus)
        {
            _isLaserEnabled = laserEnablingStatus;
        }

        private void DrawDebugLine()
        {
            Debug.DrawLine(
                DebugLineStartPosition.position,
                _lookAtPosition,
                Color.cyan,
                Time.deltaTime);
        }
    }
}
