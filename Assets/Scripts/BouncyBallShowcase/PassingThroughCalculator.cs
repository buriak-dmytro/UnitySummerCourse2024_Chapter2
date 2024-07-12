using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class PassingThroughCalculator : MonoBehaviour
    {
        public TextMeshProUGUI OutputPasshingThroughNumber;
        private int _passingThroughNumber = 0;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TriggerObject"))
            {
                _passingThroughNumber++;
                OutputPasshingThroughNumber.text = 
                    _passingThroughNumber.ToString();
            }
        }
    }
}
