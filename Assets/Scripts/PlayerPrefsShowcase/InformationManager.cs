using TMPro;
using UnityEngine;
using System.Globalization;

namespace PlayerPrefsShowcase
{
    public class InformationManager : MonoBehaviour
    {
        public TMP_InputField stringValue;
        public TMP_InputField intValue;
        public TMP_InputField floatValue;
        
        public void SaveString()
        {
            PlayerPrefs.SetString("myString", stringValue.text);
        }

        public void SaveInt()
        {
            if (int.TryParse(intValue.text, out int result))
            {
                PlayerPrefs.SetInt("myInt", result);
            }
            else
            {
                Debug.Log("Wrong int input");
            }
        }

        public void SaveFloat()
        {
            if (float.TryParse(
                    floatValue.text,
                    NumberStyles.Float, 
                    CultureInfo.CurrentCulture,
                    out float result))
            {
                PlayerPrefs.SetFloat("myFloat", result);
            }
            else
            {
                Debug.Log("Wrong float input");
            }
        }
    }
}
