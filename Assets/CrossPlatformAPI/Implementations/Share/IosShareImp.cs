using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{

    public class IosShareImp : ShareApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPIShareText(string text);

        [DllImport("__Internal")]
        private static extern void _CPAPIShareImage(string imagePath, string text);


        public override void ShareText(string text)
        {
            _CPAPIShareText(text);
        }
        public override void ShareImage(string imagePath, string text = null)
        {
            _CPAPIShareImage(imagePath, text);
        }

    }

}