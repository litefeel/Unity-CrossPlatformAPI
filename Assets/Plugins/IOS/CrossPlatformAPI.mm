#import "CrossPlatformAPI.h"

@implementation SaveToAlbumObj


- (id)init
{
    self = [super init];
    return self;
}


- (void)dealloc
{
    [super dealloc];
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

// Converts C style string to NSString
NSString* _CPAPICreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* _CPAPICopyString (const char* string)
{
    if (string == NULL)
        return NULL;
    
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}

// When native code plugin is implemented in .mm / .cpp file, then functions
// should be surrounded with extern "C" block to conform C function naming rules
extern "C" {

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
}
