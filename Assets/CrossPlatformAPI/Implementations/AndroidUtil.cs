using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class AndroidUtil
    {
        private static bool inited = false;
        public static void InitCPAPI()
        {
            if (inited) return;
            inited = true;
            
            using (AndroidJavaObject activity = GetCurrentActivity(),
                helper = new AndroidJavaClass("com.litefeel.crossplatformapi.android.utils.ActivityHelper"))
            {
                helper.CallStatic("init", activity);
            }
        }

        public static AndroidJavaClass GetUnityPlayer()
        {
            return new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        }

        public static AndroidJavaObject GetCurrentActivity()
        {
            using (var player = GetUnityPlayer())
            {
                return player.GetStatic<AndroidJavaObject>("currentActivity");
            };
        }

    }
}
