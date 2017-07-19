using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class ShareImplAndroid : ShareApi
    {

        private AndroidJavaClass api = null;

        internal ShareImplAndroid()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.AndroidPlatform");
            api.CallStatic("init", new AndroidJavaObject[] { AndroidUtil.GetCurrentActivity() });
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