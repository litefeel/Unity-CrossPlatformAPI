using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public class AndroidUtil
    {

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
