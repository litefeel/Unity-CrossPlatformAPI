using UnityEngine;
using System.Collections;
using System;

namespace litefeel
{
    public class DummyPlatform : PlatformAPI
    {

        public override void SaveToAlbum(string filename)
        {
            Debug.Log("DummyPlatform.SaveToAlbum filename:" + filename);
        }
    }
}
