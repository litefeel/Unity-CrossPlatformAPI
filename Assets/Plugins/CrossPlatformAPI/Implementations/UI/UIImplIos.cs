using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{

    public class UIImplIos : UIApi
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
        private static extern void _CPAPI_UI_ShowToast(string imagePath, int isLongTimeForDisplay);

        public override void ShowAlert(AlertParams param)
        {
            AlertParams nowparam;
            if (!CheckShowAlert(param, out nowparam))
                return;
            _AlertParams data = new _AlertParams();
            data.alertId = nowparam.alertId;
            data.title = nowparam.title;
            data.message = nowparam.message;
            data.yesButton = nowparam.yesButton;
            data.noButton = nowparam.noButton;
            data.neutralButton = nowparam.neutralButton;
            _CPAPI_UI_ShowAlert(data);
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            _CPAPI_UI_ShowToast(message, longTimeForDisplay ? 1 : 0);
        }
    }

}
