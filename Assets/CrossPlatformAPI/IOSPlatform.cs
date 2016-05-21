using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace litefeel
{
    public class IOSPlatform : PlatformAPI
    {

        [DllImport("__Internal")]
        private static extern void _CPAPISavaToAlbum(string filename);


        public override void SaveToAlbum(string filename)
        {
            _CPAPISavaToAlbum(filename);
        }
    }
}
