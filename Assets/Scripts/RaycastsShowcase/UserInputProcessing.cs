using System;
using UnityEngine;

namespace RaycastsShowcase
{
    public class UserInputProcessing : MonoBehaviour
    {
        public Camera MainCamera;

        public Action<Vector3> LookAtPosition;
        public Action<bool> LaserEnable;

        private bool _isMouseButtonPressed = false;
        private bool _isMouseButtonPressedLastFrame = false;
        private Vector3 _worldPositionOfMouseProjection;

        void Awake()
        {
            _worldPositionOfMouseProjection = transform.position;
        }

        void Update()
        {
            FindWorldPositionOfMouseProjection();
            TellLookAtPosition();

            DetermineMouseButtonStatus();
            DetermineLaserEnabling();
        }

        private void FindWorldPositionOfMouseProjection()
        {
            Vector3 mouseToCameraRelativePosition =
                CalculateMouseToCameraRelativePosition();

            Ray rayFromCameraUnderMouse =
                MainCamera.ViewportPointToRay(
                    mouseToCameraRelativePosition);

            RaycastHit raycastHit;
            if (Physics.Raycast(rayFromCameraUnderMouse, out raycastHit))
            {
                _worldPositionOfMouseProjection = raycastHit.point;
            }
        }

        private Vector3 CalculateMouseToCameraRelativePosition()
        {
            return
                new Vector3(
                    Input.mousePosition.x / MainCamera.pixelWidth,
                    Input.mousePosition.y / MainCamera.pixelHeight,
                    0.0f);
        }

        private void TellLookAtPosition()
        {
            LookAtPosition?.Invoke(_worldPositionOfMouseProjection);
        }

        private void DetermineMouseButtonStatus()
        {
            _isMouseButtonPressed = Input.GetKey(KeyCode.Mouse0);
        }

        private void DetermineLaserEnabling()
        {
            if (_isMouseButtonPressed != _isMouseButtonPressedLastFrame)
            {
                TellLaseOnPosition();
            }

            _isMouseButtonPressedLastFrame = _isMouseButtonPressed;
        }

        private void TellLaseOnPosition()
        {
            LaserEnable?.Invoke(_isMouseButtonPressed);
        }
    }
}
