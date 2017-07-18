#import "CrossPlatformAPI.h"
#import "CPA_Common.h"

@implementation SaveToAlbumObj


- (id)init
{
    self = [super init];
    return self;
}

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

static SaveToAlbumObj* saveToAlbumObj = nil;

@implementation ShareViewController

-(void) share:(NSArray*) postItems
{
    UIActivityViewController *activityVc = [[UIActivityViewController alloc]initWithActivityItems:postItems applicationActivities:nil];
    
    if ( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad && [activityVc respondsToSelector:@selector(popoverPresentationController)] ) {
        
        UIPopoverController *popup = [[UIPopoverController alloc] initWithContentViewController:activityVc];
        
        [popup presentPopoverFromRect:CGRectMake(self.view.frame.size.width/2, self.view.frame.size.height/4, 0, 0)
                               inView:[UIApplication sharedApplication].keyWindow.rootViewController.view permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];
    }
    else
        [[UIApplication sharedApplication].keyWindow.rootViewController presentViewController:activityVc animated:YES completion:nil];
}

-(void) shareText:(NSString *)text
{
    [self share: @[text]];
}

- (void) shareImage:(NSString *)filename text:(NSString *)text
{
    UIImage *image = [UIImage imageWithContentsOfFile:filename];
    
    if (text.length == 0)
        [self share: @[image]];
    else
        [self share: @[image, text]];
}

@end


// When native code plugin is implemented in .mm / .cpp file, then functions
// should be surrounded with extern "C" block to conform C function naming rules
#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPISavaToAlbum(const char* cfilename)
    {
        if (saveToAlbumObj == nil)
            saveToAlbumObj = [[SaveToAlbumObj alloc] init];
        
        NSString *filename = _CPAPICreateNSString(cfilename);
        [saveToAlbumObj save:filename];
    }
    
    void _CPAPIPasteToClipboard(const char* ctext)
    {
        NSString *text = _CPAPICreateNSString(ctext);
        UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
        pasteboard.string = text;
    }
    
    const char* _CPAPICopyFromClipboard()
    {
        UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
        // By default mono string marshaler creates .Net string for returned UTF-8 C string
        // and calls free for returned value, thus returned strings should be allocated on heap
        return _CPAPICopyString([pasteboard.string UTF8String]);
    }
    
    void _CPAPIShareText(const char* ctext)
    {
        ShareViewController *vc = [[ShareViewController alloc] init];
        [vc shareText: _CPAPICreateNSString(ctext)];
    }
    
    void _CPAPIShareImage(const char* cimage, const char* ctext)
    {
        ShareViewController *vc = [[ShareViewController alloc] init];
        [vc shareImage:_CPAPICreateNSString(cimage) text:_CPAPICreateNSString(ctext)];
    }
    
#ifdef __cplusplus
}
#endif
