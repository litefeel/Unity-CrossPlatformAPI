using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides cross-platform interface to access album.
    /// </summary>
    public abstract partial class AlbumApi
    {

        /// <summary>
        /// Save picture to album.
        /// </summary>
        /// <param name="imagePath">The full path of picture.</param>
        public abstract void SaveImage(string imagePath);
    }
}
