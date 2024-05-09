
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Simple.TestAdapter
{
    internal static class TestCaseUtils
    {
        public static TestCase CreateTestCase(string source, string testNamespace, string testClass, string testMethod, string displayName = null)
        {
            var fullyQualifiedName = $"{testNamespace}.{testClass}.{testMethod}";
            var testCase = CreateTestCase(source, fullyQualifiedName, displayName);
            return testCase;
        }
        public static TestCase CreateTestCase(string source, string fullyQualifiedName, string displayName = null)
        {
            var testCase = new TestCase(fullyQualifiedName, TestExecutor.ExecutorUri, source);

            if (!string.IsNullOrEmpty(displayName))
            {
                testCase.DisplayName = displayName;
            }

            // Do not set the GUID here, this breaks the test discovery in net core.
            //testCase.Id = GetGuid(fullyQualifiedName);

            return testCase;
        }

        private static System.Guid GetGuid(string testName)
        {
            return new System.Guid(testName.GetHashCode(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }

}