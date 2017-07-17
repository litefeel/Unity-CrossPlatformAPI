
namespace litefeel.crossplatformapi
{
    public abstract partial class ShareApi
    {
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
        internal class Default : ShareApi
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
}
