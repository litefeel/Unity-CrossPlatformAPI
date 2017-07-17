
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{

    /// <summary>
    ///  Provides cross-platform interface to access clipboard.
    /// </summary>
    public class Clipboard
    {
        private static ClipboardApi api = null;

        private static void Init()
        {
            if (api != null) return;
            CrossPlatformAPICallback.Init();
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidUtil.InitCPAPI();
            api = new AndroidClipboardImp();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new IosClipboardImp();
#else
            api = new ClipboardApi.Default();
#endif
        }


        /// <summary>
        /// Place the text into the clipboard.
        /// </summary>
        /// <param name="text">The text to be placed on the clipboard.</param>
        public static void SetText(string text)
        {
            Init();
            api.SetText(text);
        }


        /// <summary>
        /// Get text from the clipboard.
        /// </summary>
        /// <returns>The text of clipboard, default is empty text.</returns>
        public static string GetText()
        {
            Init();
            return api.GetText();
        }

    }
}
