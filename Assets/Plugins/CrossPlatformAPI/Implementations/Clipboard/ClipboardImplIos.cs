using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{
    public class ClipboardImplIos : ClipboardApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPI_Clipboard_SetText(string text);

        [DllImport("__Internal")]
        private static extern string _CPAPI_Clipboard_GetText();

        public override void SetText(string text)
        {
            _CPAPI_Clipboard_SetText(text);
        }

        public override string GetText()
        {
            return _CPAPI_Clipboard_GetText();
        }
    }
}
