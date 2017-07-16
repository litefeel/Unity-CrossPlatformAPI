
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class Clipboard
    {

        private static ClipboardApi api = null;

        private static void Init()
        {
            if (api != null) return;

#if UNITY_ANDROID && !UNITY_EDITOR
            api = new AndroidClipboardImp();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new IosClipboardImp();
#else
            api = new ClipboardApi.Default();
#endif
        }

        public static void SetText(string text)
        {
            Init();
            api.SetText(text);
        }

        public static string GetText()
        {
            Init();
            return api.GetText();
        }

    }
}
