using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{
    public abstract partial class ClipboardApi
    {

        public abstract void SetText(string text);

        [NotNull]
        public abstract string GetText();
    }
}
