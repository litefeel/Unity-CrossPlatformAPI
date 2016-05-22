using UnityEngine;
using System.Collections;
using litefeel;
using System.IO;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(Application.platform);
        print("streamingAssetsPath:" + Application.streamingAssetsPath);
        print("persistentDataPath:" + Application.persistentDataPath);

        StartCoroutine(MoveToPersistentPath());
        MoveToPersistentPath();
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
        }
    }

    public void SavaToAlbum()
    {
        string filename = Application.persistentDataPath + "/abc.png";
        CrossPlatformAPI.SaveToAlbum(filename);
    }
}
