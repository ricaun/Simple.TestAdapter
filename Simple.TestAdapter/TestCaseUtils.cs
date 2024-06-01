
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

            // Set the Id to a hash of the fully qualified name
            testCase.Id = GuidFromString(fullyQualifiedName);

            return testCase;
        }

        private static System.Guid GuidFromString(string testName)
        {
            return Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities.EqtHash.GuidFromString(testName);
        }
    }

}