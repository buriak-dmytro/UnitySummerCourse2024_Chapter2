using UnityEngine;

namespace SphereCastShowcase
{
    public enum ShootType { Raycast, SphereCast }

    public class BarrelShoot : MonoBehaviour
    {
        public ShootType ShootMethod;

        [HideIfEnumValue("ShootMethod", HideIf.Equal, (int) ShootType.Raycast)]
        public float SphereShootRadius = 2.5f;
        private bool _isDrawSphere = false;
        private Vector3 _shootEnd;
        public Transform ShootBegin;
        private RaycastHit _raycastHit;

        void Awake()
        {
            CalculateShootEnd();
        }

        void Update()
        {
            BeginShootProcess();
            DrawDebugRay();
        }

        void FixedUpdate()
        {
            CalculateShootEnd();
        }

        void OnDrawGizmos()
        {
            if (_isDrawSphere)
            {
                DrawSphere();
            }
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

        private void DrawDebugRay()
        {
            switch (ShootMethod)
            {
                case ShootType.Raycast:
                    DrawRay();
                    break;
                case ShootType.SphereCast:
                    _isDrawSphere = true;
                    break;
            }
        }

        private void DrawRay()
        {
            Debug.DrawLine(
                ShootBegin.position,
                _shootEnd,
                Color.blue,
                Time.deltaTime);
        }

        private void DrawSphere()
        {
            Gizmos.DrawWireSphere(ShootBegin.position, SphereShootRadius);
            Gizmos.DrawWireSphere(_shootEnd, SphereShootRadius);
            Gizmos.DrawLine(ShootBegin.position, _shootEnd);
        }

        private Vector3 CalculateShootEnd()
        {
            return _shootEnd = ShootBegin.position + ShootBegin.up * 20;
        }
    }
}
