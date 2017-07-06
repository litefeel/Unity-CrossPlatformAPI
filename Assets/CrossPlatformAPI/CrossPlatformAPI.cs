using UnityEngine;
using System.Collections;

namespace litefeel
{
    public static class CrossPlatformAPI
    {

        private static PlatformAPI api = null;

        private static void Init()
        {
            if (api != null) return;

            switch (Application.platform)
            {
                case RuntimePlatform.IPhonePlayer:
                    api = new IOSPlatform();
                    break;
                case RuntimePlatform.Android:
                    api = new AndroidPlatform();
                    break;
                default:
                    api = new DummyPlatform();
                    break;
            }
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
