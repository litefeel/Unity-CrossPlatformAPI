using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public class AlbumImplAndroid : AlbumApi
    {

        private AndroidJavaClass api = null;

        internal AlbumImplAndroid()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.AndroidPlatform");
            api.CallStatic("init", new AndroidJavaObject[] { AndroidUtil.GetCurrentActivity() });
        }
        
        public override void SaveImage(string imagePath)
        {
            api.CallStatic("saveToAlbum", new string[] { imagePath });
        }
    }
}