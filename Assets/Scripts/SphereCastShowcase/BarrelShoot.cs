using UnityEngine;

namespace SphereCastShowcase
{
    public enum ShootType { Raycast, SphereCast }

    public class BarrelShoot : MonoBehaviour
    {
        public ShootType ShootMethod;

        [HideIfEnumValue("ShootMethod", HideIf.Equal, (int) ShootType.Raycast)]
        public float SphereShootRadius = 2.5f;
        public Transform ShootBegin;
        private RaycastHit _raycastHit;
        
        void Update()
        {
            BeginShootProcess();
            DrawDebugLine();
        }

        private void BeginShootProcess()
        {
            switch (ShootMethod)
            {
                case ShootType.Raycast:
                    ShootRay();
                    break;
                case ShootType.SphereCast:
                    ShootSphere();
                    break;
            }
        }

        private void ShootRay()
        {
            if (IsRaycastHit())
            {
                DestroyShotObject();
            }
        }

        private bool IsRaycastHit()
        {
            return
                Physics.Raycast(
                    ShootBegin.position,
                    ShootBegin.up,
                    out _raycastHit);
        }

        private void ShootSphere()
        {
            if (IsSpherecastHit())
            {
                DestroyShotObject();
            }
        }

        private bool IsSpherecastHit()
        {
            return
                Physics.SphereCast(
                    ShootBegin.position,
                    SphereShootRadius,
                    ShootBegin.up,
                    out _raycastHit);
        }

        private void DestroyShotObject()
        {
            Destroy(_raycastHit.collider.gameObject);
        }

        private void DrawDebugLine()
        {
            Debug.DrawLine(
                ShootBegin.position,
                ShootBegin.position + ShootBegin.up * 20,
                Color.blue,
                Time.deltaTime);
        }
    }
}
