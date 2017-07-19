using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public class ClipboardImplAndroid : ClipboardApi
    {

        private AndroidJavaClass api = null;

        internal ClipboardImplAndroid()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.AndroidPlatform");
            api.CallStatic("init", new AndroidJavaObject[] { AndroidUtil.GetCurrentActivity() });
        }

        public override void SetText(string text)
        {
            api.CallStatic("pasteToClipboard", new string[] { text });
        }

        public override string GetText()
        {
            return api.CallStatic<string>("copyFromClipboard", new string[] { });
        }
    }
}