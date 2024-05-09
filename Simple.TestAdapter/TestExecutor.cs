
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using System.Collections.Generic;

namespace Simple.TestAdapter
{

    [ExtensionUri(ExecutorUriString)]
    internal class TestExecutor : TestAdapter, ITestExecutor
    {
        public void Cancel() { }

        public void RunTests(IEnumerable<TestCase> testCases, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            Initialize(runContext, frameworkHandle);

            foreach (var testCase in testCases)
            {
                Log.Informational($"[RunTests]: {testCase} [{testCase.DisplayName}] \t{testCase.Id}");
                var testResult = TestResultUtils.Create(testCase);
                frameworkHandle.RecordResult(testResult);
            }

        }

        public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            Initialize(runContext, frameworkHandle);
            foreach (var source in sources)
            {
                var testCases = TestDiscoverer.DiscoverTests(source);
                RunTests(testCases, runContext, frameworkHandle);
            }
        }
    }

}