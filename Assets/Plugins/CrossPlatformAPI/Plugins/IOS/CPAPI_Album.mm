#import "CPAPI_Common.h"
#import "CPAPI_Album.h"

@implementation CPAPI_Album


- (void) save:(NSString*) filename
{
    UIImage* image = [[UIImage alloc] initWithContentsOfFile:filename];
    UIImageWriteToSavedPhotosAlbum(image, self, @selector(image:didFinishSavingWithError:contextInfo:), nil);
}

- (void)image:(UIImage *)image didFinishSavingWithError:(NSError *)error contextInfo:(void *)contextInfo
{
    NSString *msg = nil;
    if (error != nil)
    {
        msg = @"保存图片失败";
    }else
    {
        msg = @"保存成功";
    }
    NSLog(@"%@", msg);
}

@end


#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPI_Album_SaveImage(const char* cfilename)
    {
        NSString *filename = _CPAPICreateNSString(cfilename);
        [[[CPAPI_Album alloc] init] save:filename];
    }

#ifdef __cplusplus
}
#endif
