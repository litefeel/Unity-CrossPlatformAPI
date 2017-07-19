using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public class UIImplAndroid : UIApi
    {

        private AndroidJavaClass api = null;

        internal UIImplAndroid()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.ui.UI");
        }
        
        public override void ShowAlert(AlertParams param)
        {
            AlertParams nowparam;
            if (!CheckShowAlert(param, out nowparam))
                return;
            using (var jparam = new AndroidJavaObject("com.litefeel.crossplatformapi.android.ui.AlertParams"))
            {
                jparam.Set("title", nowparam.title);
                jparam.Set("message", nowparam.message);
                jparam.Set("yesButton", nowparam.yesButton);
                jparam.Set("noButton", nowparam.noButton);
                jparam.Set("neutralButton", nowparam.neutralButton);
                jparam.Set("alertId", nowparam.alertId);
                api.CallStatic("showAlert", jparam);
            }
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            api.CallStatic("showToast", message, longTimeForDisplay);
        }
    }
}