
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class Share
    {

        private static ShareApi api = null;

        private static void Init()
        {
            if (api != null) return;

#if UNITY_ANDROID && !UNITY_EDITOR
            api = new AndroidShareImp();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new IosShareImp();
#else
            api = new ShareApi.Default();
#endif
        }

        public static void ShareImage(string imagePath, string text = null)
        {
            Init();
            api.ShareImage(imagePath, text);
        }

        public static void ShareText(string text)
        {
            Init();
            api.ShareText(text);
        }

    }
}
