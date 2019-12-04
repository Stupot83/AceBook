using System;
using System.Reflection;

namespace AceBook.Helpers
{
    static class TestDbDetectorHelper
    {
        private static bool _runningFromNUnit = false;
        static TestDbDetectorHelper()
        {
            foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Can't do something like this as it will load the nUnit assembly
                // if (assem == typeof(NUnit.Framework.Assert))
                if (assem.FullName.ToLowerInvariant().StartsWith("nunit.framework", StringComparison.Ordinal))
                {
                    _runningFromNUnit = true;
                    break;
                }
            }
        }
        public static bool IsRunningTest
        {
            get { return _runningFromNUnit || Environment.GetEnvironmentVariable("ENV") == "test"; }
        }
    }
}
