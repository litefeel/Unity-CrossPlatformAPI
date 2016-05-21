using UnityEngine;
using System.Collections;
using litefeel;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(Application.platform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SavaToAlbum()
    {
        string filename = Application.streamingAssetsPath + "/abc.png";
        CrossPlatformAPI.SaveToAlbum(filename);
    }
}
