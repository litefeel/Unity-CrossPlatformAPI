using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

namespace litefeel
{
    public class IOSPlatform : PlatformAPI
    {

        [DllImport("__Internal")]
        private static extern void _CPAPISavaToAlbum(string filename);

        [DllImport("__Internal")]
        private static extern void _CPAPIPasteToClipboard(string text);

        [DllImport("__Internal")]
        private static extern string _CPAPICopyFromClipboard();

        [DllImport("__Internal")]
        private static extern void _CPAPIShareText(string text);

        [DllImport("__Internal")]
        private static extern void _CPAPIShareImage(string image, string text);

        public override void SaveToAlbum(string filename)
        {
            _CPAPISavaToAlbum(filename);
        }

        public override void PasteToClipboard(string text)
        {
            _CPAPIPasteToClipboard(text);
        }

        public override string CopyFromClipboard()
        {
            return _CPAPICopyFromClipboard();
        }
        
        public override void NativeShareImage(string image, string text = null)
        {
            _CPAPIShareImage(image, text);
        }
        
        public override void NativeShareText(string text)
        {
            _CPAPIShareText(text);
        }
    }
}
