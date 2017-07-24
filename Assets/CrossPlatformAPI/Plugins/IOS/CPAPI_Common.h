

// Converts C style string to NSString
NSString* _CPAPICreateNSString (const char* string);

// Helper method to create C string copy
char* _CPAPICopyString (const char* string);


void _CPAPISendMessage(const char* method, const char* value);
