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

        public override void PasteToClipboard(string text)
        {
            Debug.Log("DummyPlatform.PasteToClipboard text:" + text);
        }

        public override string CopyFromClipboard()
        {
            Debug.Log("DummyPlatform.CopyFromClipboard");
            return "";
        }
    }
}
