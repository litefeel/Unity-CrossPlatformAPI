using System;

namespace litefeel.crossplatformapi
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class NotNullAttribute : Attribute
    {
    }
}
