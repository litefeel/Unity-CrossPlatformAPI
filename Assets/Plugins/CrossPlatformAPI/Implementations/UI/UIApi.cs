using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace litefeel.crossplatformapi
{
    /// <summary>
    /// Provides some interface for ui.
    /// </summary>
    public abstract class UIApi
    {
        private static Dictionary<int, AlertParams> map = new Dictionary<int, AlertParams>();

        internal static void OnAlertCb(string message)
        {
            var arr = message.Split('|');
            if (arr.Length != 2) return;
            int alertId = Convert.ToInt32(arr[0]);
            AlertParams param;
            if (!map.TryGetValue(alertId, out param)) return;
            map.Remove(alertId);

            AlertButton button = (AlertButton)(Convert.ToInt32(arr[1]));
            switch(button)
            {
                case AlertButton.Yes:
                    if (param.onYesButtonPress != null)
                        param.onYesButtonPress(button);
                    break;
                case AlertButton.No:
                    if (param.onNoButtonPress != null)
                        param.onNoButtonPress(button);
                    break;
                case AlertButton.Neutral:
                    if (param.onNeutralButtonPress != null)
                        param.onNeutralButtonPress(button);
                    break;
                default:
                    return;
            }

            if (param.onButtonPress != null)
                param.onButtonPress(button);
        }

        /// <summary>
        /// Show an native alert dialog.
        /// </summary>
        /// <param name="param">must have yesButton, ignore neutralButton when have notnoButton.</param>
        public abstract void ShowAlert(AlertParams param);

        /// <summary>
        /// Show an native alert dialog.
        /// </summary>
        /// <param name="title">The title of alert dialog.</param>
        /// <param name="message">The message of alert dialog.</param>
        /// <param name="yesButton">The yes button of alert dialog.</param>
        /// <param name="noButton">The no button of alert dialog.</param>
        /// <param name="onButtonPress">The callback delegate when press any button.</param>
        public virtual void ShowAlert(string title, string message, string yesButton, string noButton = null, OnAlertComplate onButtonPress = null)
        {
            AlertParams param = new AlertParams();
            param.title = title;
            param.message = message;
            param.yesButton = yesButton;
            param.noButton = noButton;
            param.onButtonPress = onButtonPress;
            ShowAlert(param);
        }

        internal bool CheckShowAlert(AlertParams param, out AlertParams outparam)
        {
            outparam = param;
            if (outparam.yesButton == null)
            {
                Debug.LogError("must set yesButton for UI.ShowAlert");
                return false;
            }
            if (outparam.noButton == null)
                outparam.neutralButton = null;

            outparam.alertId = CSharpUtil.GetUniqueInt();
            map.Add(outparam.alertId, outparam);
            return true;
        }

        /// <summary>
        /// Show a simple message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="longTimeForDisplay">How long to display the message, true:long, false:short</param>
        public abstract void ShowToast(string message, bool longTimeForDisplay);
    }
}
