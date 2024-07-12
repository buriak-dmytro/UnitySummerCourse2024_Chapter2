using UnityEngine;

namespace TransformComponentShowcase
{
    public class ConstantRotation : MonoBehaviour
    {
        public bool IsUseQuaternion;
        public float RotationsPerMinute;
        public Vector3 AxisOfRotation;
        
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
            transform.Rotate(AxisOfRotation, angle);
        }

        private void RotateWithQuaternionAngles(float angle)
        {
            transform.rotation *= Quaternion.AngleAxis(angle, AxisOfRotation);
        }

        private float CalculateRotationAngleInUpdate()
        {
            return
                RotationsPerMinute *
                360.0f *
                Time.deltaTime / 
                60.0f;
        }
    }
}
