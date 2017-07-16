using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{

    /// <summary>
    ///  Provides cross-platform interface to access clipboard.
    /// </summary>
    public abstract partial class ClipboardApi
    {

        /// <summary>
        /// Place the text into the clipboard.
        /// </summary>
        /// <param name="text">The text to be placed on the clipboard.</param>
        public abstract void SetText(string text);

        /// <summary>
        /// Get text from the clipboard.
        /// </summary>
        /// <returns>The text of clipboard, default is empty text.</returns>
        [NotNull]
        public abstract string GetText();
    }
}
