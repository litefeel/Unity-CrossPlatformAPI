using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{

    public class CrossPlatformAPI : MonoBehaviour
    {

        /// <summary>
        /// Cross platform api version.
        /// </summary>
        public const string version = "1.0";


        private static CrossPlatformAPI instance = null;

        internal static void Init()
        {
            if (instance == null)
            {
                var go = new GameObject("CrossPlatformAPI");
                instance = go.AddComponent<CrossPlatformAPI>();
                GameObject.DontDestroyOnLoad(go);
            }
        }

        private void OnUI_AlertCb(string message)
        {
            UIApi.OnAlertCb(message);
        }
    }

}
