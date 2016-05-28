//#if UNITY_ANDROID

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel
{
    public class AndroidPlatform : PlatformAPI
    {
        private AndroidJavaClass api = null;

        public AndroidPlatform()
        {
            api = new AndroidJavaClass("litefeel.crossplatformapi.AndroidPlatform");
            api.CallStatic("init", new string[] { });
        }

        public override void SaveToAlbum(string filename)
        {
            api.CallStatic("saveToAlbum", new string[] { filename });
        }

        public override void PasteToClipboard(string text)
        {
            api.CallStatic("pasteToClipboard", new string[] { text });
        }

        public override string CopyFromClipboard()
        {
            return api.CallStatic<string>("copyFromClipboard", new string[] {}); ;
        }
    }
}
//#endif
