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

    public void PasteToClipboard()
    {
        CrossPlatformAPI.PasteToClipboard(inputField.text);
    }

    public void CopyFromClipboard()
    {
        string text = CrossPlatformAPI.CopyFromClipboard();
        inputField.text = text;
    }

    public void NativeShare()
    {
        print("Application.streamingAssetsPath " + Application.streamingAssetsPath);
        string filename = Application.persistentDataPath + "/abc.png";
        print("share image " + filename);
        CrossPlatformAPI.NativeShareImage(filename);
    }

}
