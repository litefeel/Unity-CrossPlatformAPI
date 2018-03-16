
namespace litefeel.crossplatformapi
{
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
    public class ShareImplDummy : ShareApi
    {

        public override void ShareImage(string imagePath, string text = null)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

        public override void ShareText(string text)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

    }
#endif
}
