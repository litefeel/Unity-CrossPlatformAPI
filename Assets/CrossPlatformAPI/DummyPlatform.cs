using UnityEngine;
using System.Collections;
using System;

namespace litefeel
{
    public class DummyPlatform : PlatformAPI
    {

        public override void SaveToAlbum(string imagePath)
        {
            Debug.Log("DummyPlatform.SaveToAlbum imagePath:" + imagePath);
        }

        public override void SetToClipboard(string text)
        {
            Debug.Log("DummyPlatform.SetToClipboard text:" + text);
        }

        public override string GetFromClipboard()
        {
            Debug.Log("DummyPlatform.GetFromClipboard");
            return "";
        }
        
        public override void ShareImage(string imagePath, string text = null)
        {
            Debug.Log("DummyPlatform.ShareImage");
        }
        
        public override void ShareText(string text)
        {
            Debug.Log("DummyPlatform.ShareText");
        }
        
    }
}
