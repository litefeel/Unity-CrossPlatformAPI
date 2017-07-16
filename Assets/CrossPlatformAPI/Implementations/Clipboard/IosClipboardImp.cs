using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{
    public class IosClipboardImp : ClipboardApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPIPasteToClipboard(string text);

        [DllImport("__Internal")]
        private static extern string _CPAPICopyFromClipboard();

        public override void SetText(string text)
        {
            _CPAPIPasteToClipboard(text);
        }

        public override string GetText()
        {
            return _CPAPICopyFromClipboard();
        }
    }
}