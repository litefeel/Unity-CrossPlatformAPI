using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public static class CrossPlatformAPI
    {

        private static PlatformAPI api = null;

        private static void Init()
        {
            if (api != null) return;

#if UNITY_ANDROID && !UNITY_EDITOR
            api = new AndroidPlatform();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new IOSPlatform();
#else
            api = new DummyPlatform();
#endif
        }

        public static void SaveToAlbum(string imagePath)
        {
            Init();
            api.SaveToAlbum(imagePath);
        }

        public static void SetToClipboard(string text)
        {
            Init();
            api.SetToClipboard(text);
        }

        public static string GetFromClipboard()
        {
            Init();
            return api.GetFromClipboard();
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
