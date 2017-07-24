using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{
    public class AlbumImplIos : AlbumApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPI_Album_SaveImage(string imagePath);

        public override void SaveImage(string imagePath)
        {
            _CPAPI_Album_SaveImage(imagePath);
        }
    }
}
