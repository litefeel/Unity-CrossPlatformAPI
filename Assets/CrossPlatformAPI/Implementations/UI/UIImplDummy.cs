
namespace litefeel.crossplatformapi
{
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
    public class UIImplDummy : UIApi
    {

        public override void ShowAlert(AlertParams param)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

        public override void ShowAlert(string title, string message, string yesButton, string noButton = null, OnAlertComplate onButtonPress = null)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

        public override void ShowToast(string message, bool longTimeForDisplay)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

    }
#endif
}
