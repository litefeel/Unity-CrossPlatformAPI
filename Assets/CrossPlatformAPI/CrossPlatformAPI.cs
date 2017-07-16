using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public static class CrossPlatformAPI
    {
        [Obsolete("Method SaveToAlbum has been deprecated.Please use Album.SaveImage instead.")]
        public static void SaveToAlbum(string imagePath)
        {
            Album.SaveImage(imagePath);
        }

        [Obsolete("Method SetToClipboard has been deprecated.Please use Clipboard.SetText instead.")]
        public static void SetToClipboard(string text)
        {
            Clipboard.SetText(text);
        }

        [Obsolete("Method GetFromClipboard has been deprecated.Please use Clipboard.GetText instead.")]
        public static string GetFromClipboard()
        {
            return Clipboard.GetText();
        }

        [Obsolete("Method ShareImage has been deprecated.Please use Share.ShareImage instead.")]
        public static void ShareImage(string imagePath, string text = null)
        {
            Share.ShareImage(imagePath, text);
        }

        [Obsolete("Method ShareText has been deprecated.Please use Share.ShareText instead.")]
        public static void ShareText(string text)
        {
            Share.ShareText(text);
        }

    }

}
