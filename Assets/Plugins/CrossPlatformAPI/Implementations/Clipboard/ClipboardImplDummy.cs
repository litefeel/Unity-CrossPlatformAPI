
namespace litefeel.crossplatformapi
{
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
    public class ClipboardImplDummy : ClipboardApi
    {

        public override void SetText(string text)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

        public override string GetText()
        {
            CSharpUtil.PrintInvokeMethod();
            return "";
        }

    }
#endif
}
