
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides cross-platform interface to access album.
    /// </summary>
    public class Album
    {
        private static AlbumApi api = null;

        private static void Init()
        {
            if (api != null) return;

#if UNITY_ANDROID && !UNITY_EDITOR
            api = new AndroidAlbumImp();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new IosAlbumImp();
#else
            api = new AlbumApi.Default();
#endif
        }


        /// <summary>
        /// Save picture to album.
        /// </summary>
        /// <param name="imagePath">The full path of picture.</param>
        public static void SaveImage(string imagePath)
        {
            Init();
            api.SaveImage(imagePath);
        }

    }
}
