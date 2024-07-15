using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

namespace UnityWebRequestShowcase
{
    public class RequestManager : MonoBehaviour
    {
        public TMP_InputField fieldValue1;
        public TMP_InputField fieldValue2;
        public TMP_InputField fieldValue3;
    
        private string _pathToJSONFileOnServer;
        private string _pathToLocalJSONFile;
        private string _pathToFolderOnServer;

        void Awake()
        {
            _pathToJSONFileOnServer =
                "file:///" +
                Application.streamingAssetsPath +
                "/valuesWebServer.json";
            _pathToLocalJSONFile =
                Application.streamingAssetsPath +
                "/valuesWebLocal.json";

            _pathToFolderOnServer =
                "file:///" +
                Application.streamingAssetsPath;
        }
    
        public void POSTFileOnServerWhenDataIsSaved()
        {
            SaveInfo();
            StartCoroutine(UploadFile());
        }

        private IEnumerator UploadFile()
        {
            UnityWebRequest uwr = 
                UnityWebRequest.Post(
                    _pathToFolderOnServer, 
                    File.ReadAllText(_pathToLocalJSONFile),
                    "application/octet-stream");

            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }

            uwr.Dispose();
        }

        public void SaveInfo()
        {
            Values values = GrabInfoAndConstructDTO();
            SerializationManager.SerializeDTO(values, _pathToLocalJSONFile);
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
    
        public void GETFileFromServerSaveAndShow()
        {
            StartCoroutine(DownloadFileAndLoadOnSuccess());
        }

        private IEnumerator DownloadFileAndLoadOnSuccess()
        {
            UnityWebRequest uwr = UnityWebRequest.Get(_pathToJSONFileOnServer);
            uwr.downloadHandler = new DownloadHandlerFile(_pathToLocalJSONFile);

            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                Debug.Log("File successfully downloaded");
                LoadInfo();
            }

            uwr.Dispose();
        }

        public void LoadInfo()
        {
            Values values = 
                SerializationManager.DeserializeDTO(_pathToLocalJSONFile);
            PutInfoFromDTO(values);
        }

        private void PutInfoFromDTO(Values values)
        {
            fieldValue1.text = values.value1;
            fieldValue2.text = values.value2;
            fieldValue3.text = values.value3;
        }
    }
}
