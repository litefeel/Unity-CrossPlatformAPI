using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{
    public class AlbumImplIos : AlbumApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPISavaToAlbum(string imagePath);

        public override void SaveImage(string imagePath)
        {
            _CPAPISavaToAlbum(imagePath);
        }
    }
}