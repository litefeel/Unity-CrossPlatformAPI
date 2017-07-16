
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides cross-platform interface to various sharing services such as posting content to social media sites,
    /// sending items via email or SMS, and more.
    /// </summary>
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


        /// <summary>
        /// Share image and optional text messages.
        /// </summary>
        /// <param name="imagePath">The full path of image to be shared.</param>
        /// <param name="text">The text message to be shared.</param>
        public static void ShareImage(string imagePath, string text = null)
        {
            Init();
            api.ShareImage(imagePath, text);
        }


        /// <summary>
        /// Share text messages.
        /// </summary>
        /// <param name="text">The text message to be shared.</param>
        public static void ShareText(string text)
        {
            Init();
            api.ShareText(text);
        }

    }
}
