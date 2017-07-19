using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// this class is deprecated.
    /// @deprecated Please use specific class.
    /// @see Album Share Clipboard
    /// </summary>
    public static class CrossPlatformAPI
    {

        /// <summary>
        /// Cross platform api version.
        /// </summary>
        public const string version = "2.0";

        /// <summary>
        /// @deprecated Please use <see cref="Album.SaveImage"/> instead. 
        /// </summary>
        [Obsolete("Method SaveToAlbum has been deprecated.Please use Album.SaveImage instead.")]
        public static void SaveToAlbum(string imagePath)
        {
            Album.SaveImage(imagePath);
        }

        /// <summary>
        /// @deprecated Please use <see cref="Clipboard.SetText"/> instead. 
        /// </summary>
        [Obsolete("Method SetToClipboard has been deprecated.Please use Clipboard.SetText instead.")]
        public static void SetToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        /// <summary>
        /// @deprecated Please use <see cref="Clipboard.GetText"/> instead. 
        /// </summary>
        [Obsolete("Method GetFromClipboard has been deprecated.Please use Clipboard.GetText instead.")]
        public static string GetFromClipboard()
        {
            return Clipboard.GetText();
        }

        /// <summary>
        /// @deprecated Please use <see cref="Share.ShareImage"/> instead. 
        /// </summary>
        [Obsolete("Method ShareImage has been deprecated.Please use Share.ShareImage instead.")]
        public static void ShareImage(string imagePath, string text = null)
        {
            Share.ShareImage(imagePath, text);
        }

        /// <summary>
        /// @deprecated Please use <see cref="Share.ShareText"/> instead. 
        /// </summary>
        [Obsolete("Method ShareText has been deprecated.Please use Share.ShareText instead.")]
        public static void ShareText(string text)
        {
            Share.ShareText(text);
        }

    }

}
