using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{

    public delegate void OnAlertComplate(AlertButton button);

    public enum AlertButton
    {
        Yes = 1,
        No = 2,
        Neutral = 3,
    }
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