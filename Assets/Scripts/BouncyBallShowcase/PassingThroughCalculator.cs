using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class PassingThroughCalculator : MonoBehaviour
    {
        public TextMeshProUGUI outputPasshingThroughNumber;
        private int passingThroughNumber = 0;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TriggerObject"))
            {
                passingThroughNumber++;
                outputPasshingThroughNumber.text = 
                    passingThroughNumber.ToString();
            }
        }
    }
}
