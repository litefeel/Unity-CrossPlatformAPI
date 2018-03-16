using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class ShareImplAndroid : ShareApi
    {

        private AndroidJavaClass api = null;

        internal ShareImplAndroid()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.share.Share");
        }

        public override void ShareImage(string imagePath, string text = null)
        {
            api.CallStatic("shareImage", imagePath, text);
        }

        public override void ShareText(string text)
        {
            api.CallStatic("shareText", text);
        }
    }
}