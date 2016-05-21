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

        public static void SaveToAlbum(string filename)
        {
            Init();
            api.SaveToAlbum(filename);
        }
    }

}
