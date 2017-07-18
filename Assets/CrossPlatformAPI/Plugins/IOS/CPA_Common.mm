

// Converts C style string to NSString
NSString* _CPAPICreateNSString (const char* string)
{
    if (string)
        return [NSString stringWithUTF8String: string];
    else
        return nil;
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


extern void UnitySendMessage(const char *, const char *, const char *);



void _CPAPISendMessage(const char* method, const char* value)
{
    const char *goName = _CPAPICopyString("CrossPlatformAPI");
    UnitySendMessage(goName, _CPAPICopyString(method), _CPAPICopyString(value));
}
