using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{

    public class ShareImplIos : ShareApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPI_Share_ShareText(string text);

        [DllImport("__Internal")]
        private static extern void _CPAPI_Share_ShareImage(string imagePath, string text);


        public override void ShareText(string text)
        {
            _CPAPI_Share_ShareText(text);
        }
        public override void ShareImage(string imagePath, string text = null)
        {
            _CPAPI_Share_ShareImage(imagePath, text);
        }

    }

}
