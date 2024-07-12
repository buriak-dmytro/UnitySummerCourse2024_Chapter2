using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class PassingThroughCalculator : MonoBehaviour
    {
        public TextMeshProUGUI OutputPassingThroughNumber;
        public GameObject Sphere;
        private int _passingThroughNumber = 0;
        private Bounds _thisBounds;
        private bool _isContainsSphere = false;

        void Awake()
        {
            _thisBounds = GetComponent<Collider>().bounds;
        }

        void FixedUpdate()
        {
            CheckSpherePassing();
        }

        private void CheckSpherePassing()
        {
            if (DoesSphereEnterFirstTime())
            {
                _passingThroughNumber++;
                OutputPassingThroughNumber.text = 
                    _passingThroughNumber.ToString();

                _isContainsSphere = true;
            }
            else if (DoesSphereExitFirstTime())
            {
                _isContainsSphere = false;
            }
        }

        private bool DoesSphereEnterFirstTime()
        {
            return
                _thisBounds.Contains(Sphere.transform.position) &&
                !_isContainsSphere;
        }

        private bool DoesSphereExitFirstTime()
        {
            return
                !_thisBounds.Contains(Sphere.transform.position) &&
                _isContainsSphere;
        }
    }
}
