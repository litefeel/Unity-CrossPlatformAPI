#import "CPAPI_Common.h"
#import "CPAPI_Share.h"


@implementation CPAPI_Share

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
    
    void _CPAPI_Share_ShareText(const char* ctext)
    {
        CPAPI_Share *share = [[CPAPI_Share alloc] init];
        [share shareText: _CPAPICreateNSString(ctext)];
    }
    
    void _CPAPI_Share_ShareImage(const char* cimage, const char* ctext)
    {
        CPAPI_Share *share = [[CPAPI_Share alloc] init];
        [share shareImage:_CPAPICreateNSString(cimage) text:_CPAPICreateNSString(ctext)];
    }
    
#ifdef __cplusplus
}
#endif
