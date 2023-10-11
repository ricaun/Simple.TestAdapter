
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Simple.TestAdapter
{
    public static class TestResultUtils
    {
        public static TestResult Create(TestCase testCase)
        {
            var testResult = new TestResult(testCase);
            testResult.Outcome = TestOutcome.Passed;

            var name = testCase.FullyQualifiedName;
            if (name.Contains("Skipped"))
                testResult.Outcome = TestOutcome.Skipped;
            if (name.Contains("Failed"))
                testResult.Outcome = TestOutcome.Failed;
            if (name.Contains("None"))
                testResult.Outcome = TestOutcome.None;
            if (name.Contains("NotFound"))
                testResult.Outcome = TestOutcome.NotFound;

            return testResult;
        }
    }

}