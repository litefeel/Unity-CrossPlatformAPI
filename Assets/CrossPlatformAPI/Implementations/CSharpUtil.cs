using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace litefeel.crossplatformapi
{
    public class CSharpUtil : MonoBehaviour
    {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod(int index = 1)
        {
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(index);

            return sf.GetMethod().Name;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void PrintInvokeMethod()
        {
            UnityEngine.Debug.Log("Invoke " + GetCurrentMethod(2));
        }
    }
}
