using UnityEngine;
using System.Collections;


namespace litefeel.crossplatformapi
{
    public class CrossPlatformAPICallback : MonoBehaviour
    {
        private static CrossPlatformAPICallback instance = null;

        internal static void Init()
        {
            if (instance == null)
            {
                var go = new GameObject("CrossPlatformAPI");
                instance = go.AddComponent<CrossPlatformAPICallback>();
                GameObject.DontDestroyOnLoad(go);
            }
        }

        void OnUI_AlertCb(string message)
        {
            UIApi.OnAlertCb(message);
        }
    }
}