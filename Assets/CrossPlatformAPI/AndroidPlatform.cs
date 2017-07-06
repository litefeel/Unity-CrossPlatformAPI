#if UNITY_ANDROID

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
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

        public override void SaveToAlbum(string imagePath)
        {
            api.CallStatic("saveToAlbum", new string[] { imagePath });
        }

        public override void SetToClipboard(string text)
        {
            api.CallStatic("pasteToClipboard", new string[] { text });
        }

        public override string GetFromClipboard()
        {
            return api.CallStatic<string>("copyFromClipboard", new string[] {}); ;
        }
        
        public override void ShareImage(string imagePath, string text = null)
        {
            api.CallStatic("nativeShareImage", new string[] { imagePath, text });
        }
        
        public override void ShareText(string text)
        {
            api.CallStatic("nativeShareText", new string[] { text });
        }
    }
}
#endif
