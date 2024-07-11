using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class BouncesCalculator : MonoBehaviour
    {
        public TextMeshProUGUI outputBouncesNumber;
        private int bouncesNumber = 0;

        private void OnCollisionEnter(Collision collision)
        {
            bouncesNumber++;
            outputBouncesNumber.text = bouncesNumber.ToString();
        }
    }
}
