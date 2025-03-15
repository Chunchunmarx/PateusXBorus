using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private Dictionary<Type, Func<string, string>> callables = new Dictionary<Type, Func<string, string>>();

    // Înregistr?m fiecare clas? cu un comportament specific
    public void RegisterCaller<T>(Func<string, string> caller)
    {
        callables[typeof(T)] = caller;
    }

    public void Log(string message)
    {
        // Detect?m clasa apelant? automat
        Type callerType = GetCallerType();

        if (callerType != null && callables.ContainsKey(callerType))
        {
            string processedMessage = callables[callerType](message);
            UnityEngine.Debug.Log($"[Logger] {processedMessage}");
        }
        else
        {
            UnityEngine.Debug.Log("[Logger] No callable registered for this type.");
        }
    }

    // Metod? pentru a afla cine a apelat Logger
    private Type GetCallerType()
    {
        StackTrace stackTrace = new StackTrace();
        for (int i = 1; i < stackTrace.FrameCount; i++) // Începem de la 1 ca s? evit?m `Logger.Log()`
        {
            var method = stackTrace.GetFrame(i).GetMethod();
            if (method.DeclaringType != typeof(Logger)) // Excludem Logger-ul însu?i
                return method.DeclaringType;
        }
        return null;
    }
}
