#import "CPAPI_COMMON.h"
#import "CPAPI_Clipboard.h"

#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPI_Clipboard_SetText(const char* ctext)
    {
        NSString *text = _CPAPICreateNSString(ctext);
        UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
        pasteboard.string = text;
    }
    
    const char* _CPAPI_Clipboard_GetText()
    {
        UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];
        // By default mono string marshaler creates .Net string for returned UTF-8 C string
        // and calls free for returned value, thus returned strings should be allocated on heap
        return _CPAPICopyString([pasteboard.string UTF8String]);
    }
    
#ifdef __cplusplus
}
#endif
