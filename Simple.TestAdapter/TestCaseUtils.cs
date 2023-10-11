
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Simple.TestAdapter
{
    internal static class TestCaseUtils
    {
        public static TestCase CreateTestCase(string source, string testNamespace, string testClass, string testMethod)
        {
            var fullyQualifiedName = $"{testNamespace}.{testClass}.{testMethod}";
            return CreateTestCase(source, fullyQualifiedName);
        }
        public static TestCase CreateTestCase(string source, string fullyQualifiedName)
        {
            var testCase = new TestCase(fullyQualifiedName, TestExecutor.ExecutorUri, source);
            return testCase;
        }
    }

}