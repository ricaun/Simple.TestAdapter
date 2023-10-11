using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Simple.TestAdapter
{
    public static class SourceUtils
    {
        private static bool AnyAttribute(ICustomAttributeProvider customAttributeProvider)
        {
            return customAttributeProvider.GetCustomAttributes(true)
                .Any();
        }

        private static MethodInfo[] GetMethodInfos(Type type)
        {
            return type.GetMethods()
                .Where(e => e.DeclaringType == type)
                .ToArray();
        }

        private static string GetFullName(MethodInfo methodInfo)
        {
            return $"{methodInfo.DeclaringType.FullName}.{methodInfo.Name}";
        }

        public static List<string> GetTestNames(string source)
        {
            var testNames = new List<string>();
            try
            {
                var assembly = Assembly.Load(File.ReadAllBytes(source));
                var types = assembly.GetExportedTypes();
                var names = types.SelectMany(GetMethodInfos)
                    .Where(AnyAttribute)
                    .Select(GetFullName);

                testNames.AddRange(names);
            }
            catch { }
            return testNames;
        }
    }
}