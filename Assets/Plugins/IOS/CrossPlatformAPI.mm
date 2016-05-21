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
NSString* CreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return [NSString stringWithUTF8String: ""];
}

// Helper method to create C string copy
char* MakeStringCopy (const char* string)
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
        
        NSString *filename = [NSString stringWithUTF8String:cfilename];
        [saveToAlbumObj save:filename];
        
    }
    
}
