using UnityEngine;
using System.Collections;


namespace litefeel
{
    public abstract class PlatformAPI
    {

        public abstract void SaveToAlbum(string imagePath);
        
        public abstract void SetToClipboard(string text);

        public abstract string GetFromClipboard();
        
        public abstract void ShareImage(string imagePath, string text = null);
        public abstract void ShareText(string text);
    }
}
