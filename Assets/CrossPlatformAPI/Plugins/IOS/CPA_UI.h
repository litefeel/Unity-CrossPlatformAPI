#import <Foundation/Foundation.h>


@interface CPA_UI : NSObject<UIAlertViewDelegate>
{
    @private
    int alertId;
    int button0, button1, button2;
}



#define CPAPI_ALERTBUTTION_YES      1
#define CPAPI_ALERTBUTTION_NO       2
#define CPAPI_ALERTBUTTION_Neutral  3


struct _CPA_AlertParams {
    int alertId;
    char* title;
    char* message;
    char* yesButton;
    char* noButton;
    char* neutralButton;
};


#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPI_UI_ShowAlert(struct _CPA_AlertParams params);
    
    void _CPAPI_UI_ShowToast(const char* message, int longTimeForDisplay);

    
    
#ifdef __cplusplus
}
#endif

@end
