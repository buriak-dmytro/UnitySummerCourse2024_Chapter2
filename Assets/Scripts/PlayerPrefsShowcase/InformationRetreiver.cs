using TMPro;
using UnityEngine;

namespace PlayerPrefsShowcase
{
    public class InformationRetreiver : MonoBehaviour
    {
        public TextMeshProUGUI stringValue;
        public TextMeshProUGUI floatValue;
        public TextMeshProUGUI intValue;

        void Awake()
        {
            RetreiveString();
            RetreiveFloat();
            RetreiveInt();
        }
    
        public void RetreiveString()
        {
            if (PlayerPrefs.HasKey("myString"))
            {
                stringValue.text = PlayerPrefs.GetString("myString");
            }
            else
            {
                Debug.Log("no string saved");
            }
        }

        public void RetreiveFloat()
        {
            if (PlayerPrefs.HasKey("myFloat"))
            {
                floatValue.text = 
                    PlayerPrefs.GetFloat("myFloat").ToString("0.00");
            }
            else
            {
                Debug.Log("no float saved");
            }
        }

        public void RetreiveInt()
        {
            if (PlayerPrefs.HasKey("myInt"))
            {
                intValue.text = 
                    PlayerPrefs.GetInt("myInt").ToString();
            }
            else
            {
                Debug.Log("no int saved");
            }
        }
    }
}
