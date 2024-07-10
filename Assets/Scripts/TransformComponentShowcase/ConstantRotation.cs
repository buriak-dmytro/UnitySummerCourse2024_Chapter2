using UnityEngine;

namespace TransformComponentShowcase
{
    public class ConstantRotation : MonoBehaviour
    {
        public bool IsUseQuaternion;
        public float rotationsPerMinute;
        public Vector3 axisOfRotation;
        
        void Update()
        {
            float angle = CalculateRotationAngleInUpdate(); 

            if (IsUseQuaternion)
            {
                RotateWithQuaternionAngles(angle);
            }
            else
            {
                RotateWithTransform(angle);
            }
        }

        private void RotateWithTransform(float angle)
        {
            transform.Rotate(axisOfRotation, angle);
        }

        private void RotateWithQuaternionAngles(float angle)
        {
            transform.rotation *= Quaternion.AngleAxis(angle, axisOfRotation);
        }

        private float CalculateRotationAngleInUpdate()
        {
            return
                rotationsPerMinute *
                360.0f *
                Time.deltaTime / 
                60.0f;
        }
    }
}
