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
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.clipboard.Clipboard");
        }

        public override void SetText(string text)
        {
            api.CallStatic("setText", text);
        }

        public override string GetText()
        {
            return api.CallStatic<string>("getText");
        }
    }
}