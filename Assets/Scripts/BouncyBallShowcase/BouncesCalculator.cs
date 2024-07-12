using TMPro;
using UnityEngine;

namespace BouncyBallShowcase
{
    public class BouncesCalculator : MonoBehaviour
    {
        public TextMeshProUGUI OutputBouncesNumber;
        private int _bouncesNumber = 0;

        private void OnCollisionEnter(Collision collision)
        {
            _bouncesNumber++;
            OutputBouncesNumber.text = _bouncesNumber.ToString();
        }
    }
}
