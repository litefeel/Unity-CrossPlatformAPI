using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{

    /// <summary>
    /// The callback that any button pressed.
    /// </summary>
    /// <param name="button">Which button was pressed.</param>
    public delegate void OnAlertComplate(AlertButton button);

    /// <summary>
    /// Alert button
    /// </summary>
    public enum AlertButton
    {
        /// <summary>
        /// Yes button
        /// </summary>
        Yes = 1,
        /// <summary>
        /// No button
        /// </summary>
        No = 2,
        /// <summary>
        /// Neutral button
        /// </summary>
        Neutral = 3,
    }

    /// <summary>
    /// The params for Alert
    /// @see UI.ShowAlert
    /// </summary>
    public struct AlertParams
    {
        internal int alertId;
        public string title;
        public string message;
        public string yesButton;
        public string noButton;
        public string neutralButton;

        public OnAlertComplate onYesButtonPress;
        public OnAlertComplate onNoButtonPress;
        public OnAlertComplate onNeutralButtonPress;
        public OnAlertComplate onButtonPress;
    }
}