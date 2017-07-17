using UnityEngine;
using System.Collections;
using System;

namespace litefeel.crossplatformapi
{
    public class AndroidUIImp : UIApi
    {

        private AndroidJavaClass api = null;

        internal AndroidUIImp()
        {
            api = new AndroidJavaClass("com.litefeel.crossplatformapi.android.ui.UI");
        }
        
        public override void ShowAlert(AlertParams param)
        {
            base.ShowAlert(param);
            using (var jparam = new AndroidJavaObject("com.litefeel.crossplatformapi.android.ui.AlertParams"))
            {
                jparam.Set("title", param.title);
                jparam.Set("message", param.message);
                jparam.Set("yesButton", param.yesButton);
                jparam.Set("noButton", param.noButton);
                jparam.Set("neutralButton", param.neutralButton);
                jparam.Set("alertId", param.alertId);
                api.CallStatic("showAlert", jparam);
            }
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            api.CallStatic("showToast", message, longTimeForDisplay);
        }
    }
}