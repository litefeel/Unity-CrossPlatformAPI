using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public abstract partial class ShareApi
    {

        public abstract void ShareImage(string imagePath, string text = null);

        public abstract void ShareText(string text);
    }
}
