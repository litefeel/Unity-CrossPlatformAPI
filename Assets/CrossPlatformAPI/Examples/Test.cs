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
            Album.SaveImage(filename);
        }

        public void SetToClipboard()
        {
            Clipboard.SetText(inputField.text);
        }

        public void GetFromClipboard()
        {
            inputField.text = Clipboard.GetText();
        }

        public void ShareText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            Share.ShareText(inputField.text);
        }

        public void ShareImage()
        {
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            Share.ShareImage(filename);
        }

        public void ShareImageWithText()
        {
            if (string.IsNullOrEmpty(inputField.text))
                inputField.text = "this is shared text!";
            print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
            string filename = Application.persistentDataPath + "/screenshot.png";
            print("share image " + filename);
            Share.ShareImage(filename, inputField.text);
        }
    }
}