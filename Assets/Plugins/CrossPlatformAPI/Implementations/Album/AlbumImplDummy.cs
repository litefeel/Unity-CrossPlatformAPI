
namespace litefeel.crossplatformapi
{
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
    public class AlbumImplDummy : AlbumApi
    {

        public override void SaveImage(string imagePath)
        {
            CSharpUtil.PrintInvokeMethod();
            
        }

    }
#endif
}
