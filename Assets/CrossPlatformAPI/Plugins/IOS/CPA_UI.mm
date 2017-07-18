#import "CPA_UI.h"
#import "CPA_Common.h"




@implementation CPA_UI


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

-(void) showAlert: (struct _CPA_AlertParams) params
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

-(void) showToast:(NSString *)message longTimeForDisplay:(int)longTimeForDisplay
{
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"this is title" message:message delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
    
    [alert show];
}


# pragma mark - C API
CPA_UI* instance;
void _CPAPI_UI_ShowAlert(struct _CPA_AlertParams params)
{
    instance = [[CPA_UI alloc] init];
    [instance showAlert:params];
}

void _CPAPI_UI_ShowToast(const char* message, int longTimeForDisplay)
{
    NSString *nsmessage = _CPAPICreateNSString(message);
    instance = [[CPA_UI alloc] init];
    [instance showToast:nsmessage longTimeForDisplay:longTimeForDisplay];
}


@end

