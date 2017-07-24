

@interface CPAPI_Album : NSObject
{
    
}


- (void) save:(NSString*) filename;

- (void)image:(UIImage *)image didFinishSavingWithError:(NSError *)error contextInfo:(void *)contextInfo;

@end


#ifdef __cplusplus
extern "C" {
#endif
    
    void _CPAPI_Album_SaveImage(const char* cfilename);

    
#ifdef __cplusplus
}
#endif
