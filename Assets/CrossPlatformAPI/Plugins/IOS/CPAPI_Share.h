
@interface CPAPI_Share : UIViewController
{

}

- (void) shareText:(NSString*) text;
- (void) shareImage:(NSString*) filename text:(NSString*)text;

@end


#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPI_Share_ShareText(const char* ctext);
    
    void _CPAPI_Share_ShareImage(const char* cimage, const char* ctext);
    
#ifdef __cplusplus
}
#endif
