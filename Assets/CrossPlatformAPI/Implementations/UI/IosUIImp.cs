using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{

    public class IosUIImp : UIApi
    {

        struct _AlertParams
        {
            public int alertId;
            public string title;
            public string message;
            public string yesButton;
            public string noButton;
            public string neutralButton;
        }

        [DllImport("__Internal")]
        private static extern void _CPAPI_UI_ShowAlert(_AlertParams text);

        [DllImport("__Internal")]
        private static extern void _CPAPI_UI_ShowToast(string imagePath, bool longTimeForDisplay);

        public override void ShowAlert(AlertParams param)
        {
            base.ShowAlert(param);
            _AlertParams data = new _AlertParams();
            data.alertId = param.alertId;
            data.title = param.title;
            data.message = param.message;
            data.yesButton = param.yesButton;
            data.noButton = param.noButton;
            data.neutralButton = param.neutralButton;
            _CPAPI_UI_ShowAlert(data);
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            _CPAPI_UI_ShowToast(message, longTimeForDisplay);
        }
    }

}
