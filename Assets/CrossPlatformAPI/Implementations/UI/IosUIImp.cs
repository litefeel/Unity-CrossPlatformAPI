using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace litefeel.crossplatformapi
{

    public class IosUIImp : UIApi
    {

        [DllImport("__Internal")]
        private static extern void _CPAPI_UI_ShowAlert(AlertParams text);

        [DllImport("__Internal")]
        private static extern void _CPAPI_UI_ShowToast(string imagePath, bool longTimeForDisplay);

        public override void ShowAlert(AlertParams param)
        {
            base.ShowAlert(param);
            _CPAPI_UI_ShowAlert(param);
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            _CPAPI_UI_ShowToast(message, longTimeForDisplay);
        }
    }

}