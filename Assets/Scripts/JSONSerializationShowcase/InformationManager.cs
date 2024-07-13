using System.IO;
using TMPro;
using UnityEngine;

namespace JSONSerializationShowcase
{
    public class InformationManager : MonoBehaviour
    {
        public TMP_InputField fieldValue1;
        public TMP_InputField fieldValue2;
        public TMP_InputField fieldValue3;

        private string _pathToJSONFile;

        void Awake()
        {
            _pathToJSONFile = 
                Application.streamingAssetsPath + "/values.json";
        }

        public void SaveInfo()
        {
            Values values = GrabInfoAndConstructDTO();
            SerializeDTO(values);
        }

        private Values GrabInfoAndConstructDTO()
        {
            string value1 = fieldValue1.text;
            string value2 = fieldValue2.text;
            string value3 = fieldValue3.text;

            return
                new Values()
                {
                    value1 = value1,
                    value2 = value2,
                    value3 = value3
                };
        }

        private void SerializeDTO(Values values)
        {
            ManageNotExistedJSONFileForWriting();
            
            string json = JsonUtility.ToJson(values, true);

            WriteJSONToFile(json);
        }

        private void ManageNotExistedJSONFileForWriting()
        {
            if (!File.Exists(_pathToJSONFile))
            {
                File.Create(_pathToJSONFile).Dispose();
            }
        }

        private void WriteJSONToFile(string json)
        {
            File.WriteAllText(_pathToJSONFile, json);
        }

        public void LoadInfo()
        {
            Values values = DeserializeDTO();
            PutInfoFromDTO(values);
        }

        private Values DeserializeDTO()
        {
            if (DoesExistedJSONFileForReading())
            {
                Debug.Log($"no {_pathToJSONFile} file is found");
                return new Values();
            }

            string json = ReadJSONFromFile();

            Values values = 
                JsonUtility.FromJson<Values>(json);

            return values;
        }

        private bool DoesExistedJSONFileForReading()
        {
            return !File.Exists(_pathToJSONFile);
        }

        private string ReadJSONFromFile()
        {
            return File.ReadAllText(_pathToJSONFile);
        }

        private void PutInfoFromDTO(Values values)
        {
            fieldValue1.text = values.value1;
            fieldValue2.text = values.value2;
            fieldValue3.text = values.value3;
        }
    }
}
