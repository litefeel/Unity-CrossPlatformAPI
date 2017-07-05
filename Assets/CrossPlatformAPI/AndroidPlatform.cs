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
            var player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            var currentActivity = player.GetStatic<AndroidJavaObject>("currentActivity");

            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.AndroidPlatform");
            api.CallStatic("init", new AndroidJavaObject[] { currentActivity });
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
