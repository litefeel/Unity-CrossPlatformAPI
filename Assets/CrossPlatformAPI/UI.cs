
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides some interface for ui.
    /// </summary>
    public class UI
    {
        private static UIApi api = null;

        private static void Init()
        {
            if (api != null) return;
            CrossPlatformAPICallback.Init();
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidUtil.InitCPAPI();
            api = new UIImplAndroid();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new UIImplIos();
#else
            api = new UIImplDummy();
#endif
        }


        /// <summary>
        /// Show an native alert dialog.
        /// </summary>
        /// <param name="param">must have yesButton, ignore neutralButton when have notnoButton.</param>
        public static void ShowAlert(AlertParams param)
        {
            Init();
            api.ShowAlert(param);
        }


        /// <summary>
        /// Show an native alert dialog.
        /// </summary>
        /// <param name="param">must have yesButton, ignore neutralButton when have notnoButton.</param>
        public static void ShowAlert(string title, string message, string yesButton, string noButton = null, OnAlertComplate onButtonPress = null)
        {
            Init();
            api.ShowAlert(title, message, yesButton, noButton, onButtonPress);
        }


        /// <summary>
        /// Show a simple message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="longTimeForDisplay">How long to display the message, true:long, false:short</param>
        public static void ShowToast(string message, bool longTimeForDisplay)
        {
            Init();
            api.ShowToast(message, longTimeForDisplay);
        }

    }
}
