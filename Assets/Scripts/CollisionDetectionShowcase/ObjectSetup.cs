using UnityEngine;

namespace CollisionDetectionShowcase
{
    public class ObjectSetup : MonoBehaviour
    {
        public float InitialImpulseForce;
        public float InitialTorque;
        public CollisionDetectionMode CDM;
        private Rigidbody _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.collisionDetectionMode = CDM;
            Time.timeScale = 0.1f;
        }

        void Start()
        {
            _rb.AddForce(
                -transform.right * InitialImpulseForce,
                ForceMode.Impulse);

            _rb.AddTorque(
                transform.up * InitialTorque,
                ForceMode.Impulse);
        }
    }
}
