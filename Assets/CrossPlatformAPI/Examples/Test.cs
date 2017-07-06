using UnityEngine;
using System.Collections;
using litefeel;
using System.IO;
using UnityEngine.UI;

public class Test : MonoBehaviour {

    public InputField inputField;

	// Use this for initialization
	void Start () {
        print(Application.platform);
        print("streamingAssetsPath:" + Application.streamingAssetsPath);
        print("persistentDataPath:" + Application.persistentDataPath);

        StartCoroutine(MoveToPersistentPath());

        if (inputField == null)
        {
            inputField = GameObject.Find("InputField").GetComponent<InputField>();
        }
    }

    // Update is called once per frame
    IEnumerator MoveToPersistentPath () {
        string filename = Application.streamingAssetsPath + "/abc.png";
        WWW www = new WWW(filename);
        yield return www;
        if (www.error != null)
        {
            print("can not load file form " + filename);
            // IOS can not move file via WWW, so move it via file api
            File.WriteAllBytes(Application.persistentDataPath + "/abc.png", File.ReadAllBytes(filename));
        } else
        {
            File.WriteAllBytes(Application.persistentDataPath + "/abc.png", www.bytes);
            www.Dispose();
            print("write file to " + Application.persistentDataPath + "/abc.png");
        }
    }

    public void SavaToAlbum()
    {
        string filename = Application.persistentDataPath + "/abc.png";
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
        string filename = Application.persistentDataPath + "/abc.png";
        print("share image " + filename);
        CrossPlatformAPI.ShareImage(filename);
    }

    public void ShareImageWithText()
    {
        if (string.IsNullOrEmpty(inputField.text))
            inputField.text = "this is shared text!";
        print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
        string filename = Application.persistentDataPath + "/abc.png";
        print("share image " + filename);
        CrossPlatformAPI.ShareImage(filename, inputField.text);
    }
}
