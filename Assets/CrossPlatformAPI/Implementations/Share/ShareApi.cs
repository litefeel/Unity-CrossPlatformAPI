using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides cross-platform interface to various sharing services such as posting content to social media sites,
    /// sending items via email or SMS, and more.
    /// </summary>
    public abstract class ShareApi
    {

        /// <summary>
        /// Share image and optional text messages.
        /// </summary>
        /// <param name="imagePath">The full path of image to be shared.</param>
        /// <param name="text">The text message to be shared.</param>
        public abstract void ShareImage(string imagePath, string text = null);

        /// <summary>
        /// Share text messages.
        /// </summary>
        /// <param name="text">The text message to be shared.</param>
        public abstract void ShareText(string text);
    }
}
