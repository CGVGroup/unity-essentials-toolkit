using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using Directory = UnityEngine.Windows.Directory;

namespace cgvg.EssentialsToolkit
{
    public static class CommandLineArguments
    {
        private static Dictionary<string, string> arguments;

        static CommandLineArguments()
        {
            ParseCommandLineArguments();
        }

        private static void ParseCommandLineArguments()
        {
            string[] args = new []{""};
            arguments = new Dictionary<string, string>();

            #if UNITY_EDITOR
            string editorCommandLineArgsFilePath = Path.Combine(Application.dataPath, "CommandLine", "editor-commandline-args.txt"); 
            if (File.Exists(editorCommandLineArgsFilePath))
            {
                string editorCommandLineArguments = File.ReadAllText(editorCommandLineArgsFilePath);
                args = editorCommandLineArguments.Split(new char[] { ' ', '\n' });
            }
            #else
            args = Environment.GetCommandLineArgs();
            #endif

            
            for (var i = 0; i < args.Length; i++)
                // Arguments are now in the format: -key=value
                if (args[i].StartsWith("-"))
                {
                    var parts = args[i].Substring(1).Split('=');
                    if (parts.Length == 2)
                        arguments[parts[0]] = parts[1];
                    else
                        Debug.LogWarning("Invalid command line argument format: " + args[i]);
                }
        }

        public static string GetString(string key, string defaultValue = null)
        {
            if (arguments.TryGetValue(key, out var value)) return value;

            return defaultValue;
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            if (arguments.TryGetValue(key, out var value) && int.TryParse(value, out var result)) return result;

            return defaultValue;
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            if (arguments.TryGetValue(key, out var value))
                // Consider true for "true", "1", "yes" or "on"; false otherwise
                return value.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                       value.Equals("1") ||
                       value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                       value.Equals("on", StringComparison.OrdinalIgnoreCase);

            return defaultValue;
        }

        public static float GetFloat(string key, float defaultValue = 0f)
        {
            if (arguments.TryGetValue(key, out var value) && float.TryParse(value, NumberStyles.Any,
                    CultureInfo.InvariantCulture, out var result)) return result;

            return defaultValue;
        }
    }
}