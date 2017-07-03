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
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.AndroidPlatform");
            api.CallStatic("init");
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
        
        public override void NativeShareImage(string image, string text = null)
        {
            api.CallStatic("nativeShareImage", new string[] { image, text });
        }
        
        public override void NativeShareText(string text)
        {
            api.CallStatic("nativeShareText", new string[] { text });
        }
    }
}
//#endif
