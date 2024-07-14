using System.IO;
using UnityEngine;

namespace UnityWebRequestShowcase
{
    public static class SerializationManager
    {
        public static void SerializeDTO(Values values, string pathToJSONFile)
        {
            ManageNotExistedJSONFileForWriting(pathToJSONFile);
            
            string json = JsonUtility.ToJson(values, true);

            WriteJSONToFile(json, pathToJSONFile);
        }

        private static void ManageNotExistedJSONFileForWriting(string pathToJSONFile)
        {
            if (!File.Exists(pathToJSONFile))
            {
                File.Create(pathToJSONFile).Dispose();
            }
        }

        private static void WriteJSONToFile(string json, string pathToJSONFile)
        {
            File.WriteAllText(pathToJSONFile, json);
        }

        public static Values DeserializeDTO(string pathToJSONFile)
        {
            if (DoesExistedJSONFileForReading(pathToJSONFile))
            {
                Debug.Log($"no {pathToJSONFile} file is found");
                return new Values();
            }

            string json = ReadJSONFromFile(pathToJSONFile);

            Values values = 
                JsonUtility.FromJson<Values>(json);

            return values;
        }

        private static bool DoesExistedJSONFileForReading(string pathToJSONFile)
        {
            return !File.Exists(pathToJSONFile);
        }

        private static string ReadJSONFromFile(string pathToJSONFile)
        {
            return File.ReadAllText(pathToJSONFile);
        }

    }
}
