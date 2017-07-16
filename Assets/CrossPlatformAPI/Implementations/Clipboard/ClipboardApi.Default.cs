
namespace litefeel.crossplatformapi
{
    public abstract partial class ClipboardApi
    {
#if !UNITY_IOS && !UNITY_ANDROID
        internal class Default : ClipboardApi
        {

            public override void SetText(string text)
            {
                CSharpUtil.PrintInvokeMethod();
                
            }

            public override string GetText()
            {
                CSharpUtil.PrintInvokeMethod();
                return null;
            }

        }
#endif
    }
}
