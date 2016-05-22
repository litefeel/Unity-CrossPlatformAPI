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
        }

        public override void SaveToAlbum(string filename)
        {
            api.CallStatic("saveToAlbum", new string[] { filename });
        }
    }
}
//#endif
