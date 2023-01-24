using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Debug = UnityEngine.Debug;


namespace cgvg.EssentialsToolkit
{
    public static class Utility
    {
        public static void Log(string arg)
        {
            //if(UnityEngine.Debug.isDebugBuild)
            {
#if UNITY_EDITOR || !UNITY_WSA

                StackFrame frame = new StackFrame(1);

                var method = frame.GetMethod();
                var type = method.DeclaringType;
                var name = method.Name;

                Debug.Log(type + "::" + name + " " + arg);

#else
    /*
    	StackTrace st = new StackTrace(new Exception(), true);
    
    	StackFrame frame = st.GetFrames()[1];
    
     	var method = frame.GetMethod();
    	var type = method.DeclaringType;
    	var name = method.Name;
    
    	UnityEngine.Debug.Log(type + "::" + name + " " + arg);
    */
    	UnityEngine.Debug.Log(arg);

#endif
            }
        }


        public static void LogWarning(string arg)
        {
            //if(UnityEngine.Debug.isDebugBuild)
            {
#if UNITY_EDITOR || !UNITY_WSA

                StackFrame frame = new StackFrame(1);

                var method = frame.GetMethod();
                var type = method.DeclaringType;
                var name = method.Name;

                Debug.LogWarning(type + "::" + name + " " + arg);

#else
    	UnityEngine.Debug.LogWarning(arg);

#endif
            }
        }


        public static void LogError(string arg)
        {
            //if(UnityEngine.Debug.isDebugBuild)
            {
#if UNITY_EDITOR || !UNITY_WSA

                StackFrame frame = new StackFrame(1);

                var method = frame.GetMethod();
                var type = method.DeclaringType;
                var name = method.Name;

                Debug.LogError(type + "::" + name + " " + arg);

#else
    	UnityEngine.Debug.LogError(arg);

#endif
            }
        }
        
        
        public static float Remap(this float value, float fromMin, float fromMax, float toMin, float toMax)
        {
            return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
        }

        public static string CleanString(string stringToClean, params string[] stringsToRemove)
        {
            string result = "";

            for (int i = 0; i < stringsToRemove.Length; i++)
            {
                result = stringToClean.Replace(stringsToRemove[i], String.Empty);
            }

            result = result.TrimStart();
            result = result.TrimEnd();

            return result;
        }
    }
}