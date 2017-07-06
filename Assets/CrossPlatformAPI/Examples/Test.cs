using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

namespace litefeel.crossplatformapi
{
    public class Test : MonoBehaviour
    {

        public InputField inputField;

        // Use this for initialization
        void Start()
        {
            print(Application.platform);
            print("streamingAssetsPath:" + Application.streamingAssetsPath);
            print("persistentDataPath:" + Application.persistentDataPath);
            
            if (inputField == null)
            {
                inputField = GameObject.Find("InputField").GetComponent<InputField>();
            }

#if !UNITY_EDITOR
            Application.CaptureScreenshot("screenshot.png");
#endif
        }
        
        public void SavaToAlbum()
        {
            string filename = Application.persistentDataPath + "/screenshot.png";
            CrossPlatformAPI.SaveToAlbum(filename);
        }

        public void SetToClipboard()
        {
            CrossPlatformAPI.SetToClipboard(inputField.text);
        }

        public void GetFromClipboard()
        {
            string text = CrossPlatformAPI.GetFromClipboard();
            inputField.text = text;
        }

        public void ShareText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            CrossPlatformAPI.ShareText(inputField.text);
        }

        public void ShareImage()
        {
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            CrossPlatformAPI.ShareImage(filename);
        }

        public void ShareImageWithText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            CrossPlatformAPI.ShareImage(filename, inputField.text);
        }
    }
}