using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;
using litefeel.crossplatformapi;
using System.Text.RegularExpressions;

public class CPAGenTool {

    private static string BasePath = Application.dataPath + "/CrossPlatformAPI";
    private static string NAMESPACE = "litefeel.crossplatformapi";

    [MenuItem("CPAGen/Gen")]
    static void Gen()
    {
        Debug.Log(Application.dataPath);
        var types = GetTypesInNamespace(NAMESPACE);
        Debug.Log(types.Count);
        foreach(var type in types)
        {
            Debug.Log(type + "|" + type.Name +"|"+type.FullName+"|"+type.AssemblyQualifiedName);
            GenDefaultClass(type);
            GenTopClass(type);
        }
    }

    private static List<Type> GetTypesInNamespace(string nameSpace, Assembly assembly = null)
    {
        if (assembly == null)
            assembly = Assembly.GetAssembly(typeof(litefeel.crossplatformapi.Clipboard));
        return assembly.GetTypes()
            .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
            .Where(t => t.IsAbstract && t.Name.EndsWith("Api"))
            .ToList<Type>();
    }
    
    private static string TopClassFormat = @"
using UnityEngine;
using System.Collections;

namespace litefeel.crossplatformapi
{{
{1}    public class {0}
    {{
        private static {0}Api api = null;

        private static void Init()
        {{
            if (api != null) return;
            CrossPlatformAPICallback.Init();
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidUtil.InitCPAPI();
            api = new Android{0}Imp();
#elif UNITY_IOS && !UNITY_EDITOR
            api = new Ios{0}Imp();
#else
            api = new {0}Api.Default();
#endif
        }}
{2}
    }}
}}
";

    private static string TopClassMethod = @"
{5}        public static {0} {1}({2})
        {{
            Init();
            {4}api.{1}({3});
        }}
";
    
    private static void GenTopClass(Type apiType)
    {

        var methodBuilder = new StringBuilder();

        foreach (var method in apiType.GetMethods(BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            string returns = method.ReturnType == typeof(void) ? "" : "return ";

            var defParams = new StringBuilder();
            var callParams = new StringBuilder();
            foreach (var param in method.GetParameters())
            {
                callParams.Append(param.Name).Append(", ");
                defParams.Append(Type2Str(param.ParameterType)).Append(" ")
                    .Append(param.Name);
                if (param.IsOptional)
                    defParams.Append(" = ").Append(DefaultValue2Str(param.RawDefaultValue));
                defParams.Append(", ");
            }
            if (defParams.Length > 2)
            {
                defParams.Length -= 2;
                callParams.Length -= 2;
            }
            var methodComment = GetMethodComment(apiType, method);
            methodBuilder.AppendFormat(TopClassMethod, Type2Str(method.ReturnType), method.Name, defParams.ToString(), callParams.ToString(), returns, methodComment);
        }


        var clsName = apiType.Name.Substring(0, apiType.Name.Length - 3);
        var content = string.Format(TopClassFormat, clsName, GetClassComment(apiType), methodBuilder);

        var path = string.Format("{0}/{1}.cs", BasePath, clsName);
        File.WriteAllText(path, content);
    }


    private static string DefaultClassFormat = @"
namespace litefeel.crossplatformapi
{{
    public abstract partial class {0}Api
    {{
#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)
        internal class Default : {0}Api
        {{
{1}
        }}
#endif
    }}
}}
";

    private static string DefaultClassMethod = @"
            public override {0} {1}({2})
            {{
                CSharpUtil.PrintInvokeMethod();
                {3}
            }}
";

    private static void GenDefaultClass(Type apiType)
    {
        var methodBuilder = new StringBuilder();

        foreach (var method in apiType.GetMethods(BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            bool notNull = method.IsDefined(typeof(NotNullAttribute), false);
            string returns = method.ReturnType == typeof(void) ? "" : "return " + DefaultValue2Str(method.ReturnType, notNull) + ";";

            var defParams = new StringBuilder();
            foreach (var param in method.GetParameters())
            {
                defParams.Append(Type2Str(param.ParameterType)).Append(" ")
                    .Append(param.Name);
                if (param.IsOptional)
                    defParams.Append(" = ").Append(DefaultValue2Str(param.RawDefaultValue));
                defParams.Append(", ");
            }
            if (defParams.Length > 2)
            {
                defParams.Length -= 2;
            }
            methodBuilder.AppendFormat(DefaultClassMethod, Type2Str(method.ReturnType), method.Name, defParams, returns);
        }


        var clsName = apiType.Name.Substring(0, apiType.Name.Length - 3);
        var content = string.Format(DefaultClassFormat, clsName, methodBuilder);

        var path = string.Format("{0}/Implementations/{1}/{1}Api.Default.cs", BasePath, clsName);
        File.WriteAllText(path, content);
    }

    private static string GetClassComment(Type apiType)
    {
        var clsName = apiType.Name.Substring(0, apiType.Name.Length - 3);
        var path = string.Format("{0}/Implementations/{1}/{1}Api.cs", BasePath, clsName);
        var content = File.ReadAllText(path);

        var expr = new StringBuilder("((^\\s*?//[^\n]*?$\r?\n)+)")
            .Append("(^\\s*?\\[[^\\[]*][^\n]*\n)*") // Attribute
            .Append("^\\s*public abstract partial class ").Append(apiType.Name);
        
        Debug.Log(expr.ToString());
        var match = Regex.Match(content, expr.ToString(), RegexOptions.Multiline|RegexOptions.Singleline);
        if (match.Success)
            Debug.Log(match.Groups[1].Value);
        return match.Success ? match.Groups[1].Value : "";
    }

    /// <summary>
    /// Share image and optional text messages.
    /// </summary>
    /// <param name="imagePath">The full path of image to be shared.</param>
    /// <param name="text">The text message to be shared.</param>
    //public abstract void ShareImage(string imagePath, string text = null);
    private static string GetMethodComment(Type apiType, MethodInfo method)
    {
        var clsName = apiType.Name.Substring(0, apiType.Name.Length - 3);
        var path = string.Format("{0}/Implementations/{1}/{1}Api.cs", BasePath, clsName);
        var content = File.ReadAllText(path);

        var expr = new StringBuilder("((^\\s*?//[^\n]*?$\r?\n)+)")
            .Append("(^\\s*?\\[[^\\[]*][^\n]*\n)*") // Attribute
            .Append("^\\s*public abstract \\S+ ").Append(method.Name)
            .Append("\\(.*?");
        foreach (var param in method.GetParameters())
            expr.Append(param.Name).Append(".*?");
        expr.Append("\\)");
        Debug.Log(expr.ToString());
        var match = Regex.Match(content, expr.ToString(), RegexOptions.Multiline | RegexOptions.Singleline);
        if (match.Success)
            Debug.Log(match.Groups[1].Value);
        return match.Success ? match.Groups[1].Value : "";
    }

    private static Dictionary<Type, string> typeStrMap = new Dictionary<Type, string>
    {
        { typeof(void),     "void" },
        { typeof(bool),     "bool" },
        { typeof(int),      "int" },
        { typeof(float),    "float" },
        { typeof(string),   "string" }
    };
    

    private static string Type2Str(Type type)
    {
        string str;
        if (typeStrMap.TryGetValue(type, out str))
            return str;
        if (type.IsPrimitive)
            return type.Name;
        return type.FullName;
    }

    private static string DefaultValue2Str(object value)
    {
        if (value == null)
            return "null";
        if (value.GetType() == typeof(string))
            return string.Format("\"{0}\"", value);
        return value.ToString();
    }

    private static string DefaultValue2Str(Type type, bool notNull = false)
    {
        if (notNull && type == typeof(string))
            return "\"\"";
        if (!type.IsValueType)
            return "null";
        return DefaultValue2Str(Activator.CreateInstance(type));
    }
}
