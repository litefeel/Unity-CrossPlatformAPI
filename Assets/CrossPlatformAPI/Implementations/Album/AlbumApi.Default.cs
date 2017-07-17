
namespace litefeel.crossplatformapi
{
    public abstract partial class AlbumApi
    {
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
        internal class Default : AlbumApi
        {

            public override void SaveImage(string imagePath)
            {
                CSharpUtil.PrintInvokeMethod();
                
            }

        }
#endif
    }
}
