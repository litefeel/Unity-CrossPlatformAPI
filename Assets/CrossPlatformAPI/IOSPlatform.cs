#if UNITY_IOS

using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace litefeel.crossplatformapi
{
    public class IOSPlatform : PlatformAPI
    {

        [DllImport("__Internal")]
        private static extern void _CPAPISavaToAlbum(string imagePath);

        [DllImport("__Internal")]
        private static extern void _CPAPIPasteToClipboard(string text);

        [DllImport("__Internal")]
        private static extern string _CPAPICopyFromClipboard();

        [DllImport("__Internal")]
        private static extern void _CPAPIShareText(string text);

        [DllImport("__Internal")]
        private static extern void _CPAPIShareImage(string imagePath, string text);

        public override void SaveToAlbum(string imagePath)
        {
            _CPAPISavaToAlbum(imagePath);
        }

        public override void SetToClipboard(string text)
        {
            _CPAPIPasteToClipboard(text);
        }

        public override string GetFromClipboard()
        {
            return _CPAPICopyFromClipboard();
        }
        
        public override void ShareImage(string imagePath, string text = null)
        {
            _CPAPIShareImage(imagePath, text);
        }
        
        public override void ShareText(string text)
        {
            _CPAPIShareText(text);
        }
    }
}
#endif