
namespace litefeel.crossplatformapi
{
    public abstract partial class UIApi
    {
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
        internal class Default : UIApi
        {

            public override void ShowAlert(AlertParams param)
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
}
