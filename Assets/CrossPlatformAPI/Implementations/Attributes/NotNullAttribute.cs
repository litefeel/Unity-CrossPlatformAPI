using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace litefeel.crossplatformapi
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class NotNullAttribute : Attribute
    {
    }
}
