#import "CPAPI_UI.h"
#import "CPAPI_Common.h"




@implementation CPAPI_UIAlert


// Called when a button is clicked. The view will be automatically dismissed after this call returns
- (void)alertView:(UIAlertView *)alertView clickedButtonAtIndex:(NSInteger)buttonIndex
{
    int button = button0;
    switch (buttonIndex) {
        case 0:
            button = button0;
            break;
        case 1:
            button = button1;
            break;
        case 2:
            button = button2;
            break;
            
        default:
            return;
            break;
    }
    NSString *str = [NSString stringWithFormat:@"%d|%d", alertId, button];
    _CPAPISendMessage("OnUI_AlertCb", [str UTF8String]);
}

-(void) showAlert: (struct _CPAPI_AlertParams) params
{
    alertId = params.alertId;
    
    NSString *title = _CPAPICreateNSString(params.title);
    NSString *message = _CPAPICreateNSString(params.message);
    NSString *yesButton = _CPAPICreateNSString(params.yesButton);
    NSString *noButton = _CPAPICreateNSString(params.noButton);
    NSString *neutralButton = _CPAPICreateNSString(params.neutralButton);
    
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:title message:message delegate:self cancelButtonTitle:noButton otherButtonTitles:yesButton, nil];
    
    button0 = CPAPI_ALERTBUTTION_YES;
    button1 = button2 = 999;
    
    if (noButton != nil) {
        button0 = CPAPI_ALERTBUTTION_NO;
        button1 = CPAPI_ALERTBUTTION_YES;
    }
    
    if (neutralButton != nil) {
        [alert addButtonWithTitle:neutralButton];
        button2 = CPAPI_ALERTBUTTION_Neutral;
    }
    
    [alert show];

}

@end


@interface CPAPI_UIToast ()
@property (strong, nonatomic) UILabel *label;
@end
@implementation CPAPI_UIToast

//float const ToastHeight = 50.0f;
//float const ToastGap = 10.0f;


+ (void)showToastInParentView: (UIView *)parentView withText:(NSString *)text withDuration:(float)duration;
{
    
    //Count toast views are already showing on parent. Made to show several toasts one above another
    //int toastsAlreadyInParent = 0;
    //for (UIView *subView in [parentView subviews]) {
    //    if ([subView isKindOfClass:[ToastView class]])
    //    {
    //        toastsAlreadyInParent++;
    //    }
    //}
    
    float hLabelGap = 40.0;
    float vLabelGap = 20.0;
    float hToastGap = 20.0;
    float vToastGap = 10.0;
    
    CGRect labelFrame = CGRectMake(parentView.frame.origin.x + hLabelGap,
                                   parentView.frame.origin.y + vLabelGap,
                                   parentView.frame.size.width - 2 * hLabelGap,
                                   parentView.frame.size.height - 2 * vLabelGap);
    
    
    
    UILabel *label = [[UILabel alloc] initWithFrame:labelFrame];
    label.backgroundColor = [UIColor clearColor];
    label.textAlignment = NSTextAlignmentLeft;
    label.textColor = [UIColor whiteColor];
    label.numberOfLines = 0;
    label.font = [UIFont systemFontOfSize:15.0];
    label.lineBreakMode = NSLineBreakByWordWrapping;
    label.text = text;
    [label sizeToFit];
    
    labelFrame = label.frame;
    CGRect parentFrame = parentView.frame;
    CGRect toastFrame = CGRectMake(labelFrame.origin.x - hToastGap,
                                   labelFrame.origin.y - vToastGap,
                                   labelFrame.size.width + 2 * hToastGap,
                                   labelFrame.size.height + 2 * vToastGap);
    toastFrame = CGRectMake((parentFrame.size.width - toastFrame.size.width) / 2,
                            parentFrame.size.height - toastFrame.size.height - 70,
                            toastFrame.size.width,
                            toastFrame.size.height);
    
    
    CPAPI_UIToast *toast = [[CPAPI_UIToast alloc] initWithFrame:toastFrame];
    toast.backgroundColor = [UIColor darkGrayColor];
    toast.alpha = 0.0f;
    toast.layer.cornerRadius = 20.0f;
    //toast.center = parentView.center;
    label.center = CGPointMake(toastFrame.size.width / 2, toastFrame.size.height / 2);
    toast.label = label;
    [toast addSubview:label];
    [toast setUserInteractionEnabled:NO];
    
    [parentView addSubview:toast];
    
    [UIView animateWithDuration:0.4 animations:^{
        toast.alpha = 0.9f;
        label.alpha = 0.9f;
    }completion:^(BOOL finished) {
        if(finished){
            
        }
    }];
    
    
    [toast performSelector:@selector(hideSelf) withObject:nil afterDelay:duration];
    
}

- (void)hideSelf
{
    
    [UIView animateWithDuration:0.4 animations:^{
        self.alpha = 0.0;
        self.label.alpha = 0.0;
    }completion:^(BOOL finished) {
        if(finished){
            [self removeFromSuperview];
        }
    }];
}

@end

#ifdef __cplusplus
extern "C" {
#endif
//# pragma mark - C API
void _CPAPI_UI_ShowAlert(struct _CPAPI_AlertParams params)
{
    CPAPI_UIAlert *instance = [[CPAPI_UIAlert alloc] init];
    [instance showAlert:params];
}

void _CPAPI_UI_ShowToast(const char* message, int longTimeForDisplay)
{
    UIView *rootView = [UIApplication sharedApplication].keyWindow.rootViewController.view;
    NSString *nsmessage = _CPAPICreateNSString(message);
    float duration = longTimeForDisplay ? 3.5 : 2;
    [CPAPI_UIToast showToastInParentView:rootView withText:nsmessage withDuration:duration];
}

#ifdef __cplusplus
}
#endif


