
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Simple.TestAdapter
{
    [DefaultExecutorUri(ExecutorUriString)]
    [FileExtension(".dll")]
    internal class TestDiscoverer : TestAdapter, ITestDiscoverer
    {
        public void DiscoverTests(
            IEnumerable<string> sources,
            IDiscoveryContext discoveryContext,
            IMessageLogger logger,
            ITestCaseDiscoverySink discoverySink)
        {
            Initialize(discoveryContext, logger);
            foreach (var source in sources)
            {
                DiscoverTests(source, discoverySink);
            }
        }

        public void DiscoverTests(
            string source,
            ITestCaseDiscoverySink discoverySink)
        {
            Log.Informational($"[DiscoverTests]: {source}");

            if (CanDiscoverTests(source) == false)
            {
                Log.Informational($"[DiscoverTests]: File '{Path.GetFileName(source)}' not end with '.Tests'.");
                return;
            }

            foreach (var testCase in DiscoverTests(source))
            {
                Log.Informational($"[TestCase]: {testCase} [{testCase.DisplayName}] \t{testCase.Id}");
                discoverySink?.SendTestCase(testCase);
            }
        }

        private bool CanDiscoverTests(string source)
        {
            return Path.GetFileNameWithoutExtension(source)
                .EndsWith(".Tests", System.StringComparison.CurrentCultureIgnoreCase);
        }

        public static List<TestCase> DiscoverTests(
            string source)
        {
            var testCases = new List<TestCase>();

            var testNamespace = "Simple";

            var testCaseName = TestCaseUtils.CreateTestCase(source, testNamespace, "Assembly", "FileName");
            testCaseName.DisplayName = "FileName: " + Path.GetFileNameWithoutExtension(source);
            testCases.Add(testCaseName);

            var testCaseInfo = TestCaseUtils.CreateTestCase(source, testNamespace, "Assembly", "FileVersion");
            testCaseInfo.DisplayName = "FileVersion: " + FileVersionInfo.GetVersionInfo(source).FileVersion;
            testCases.Add(testCaseInfo);

            var testNames = SourceUtils.GetTestNames(source);
            testCases.AddRange(testNames.Select(e => TestCaseUtils.CreateTestCase(source, e)));

            return testCases;
        }
    }
}