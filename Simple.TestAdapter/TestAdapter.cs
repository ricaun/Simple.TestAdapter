using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System;

namespace Simple.TestAdapter
{
    internal abstract class TestAdapter
    {
        public const string ExecutorUriString = "executor://Simple.TestExecutor/v1";
        public static readonly Uri ExecutorUri = new Uri(ExecutorUriString);

        private IDiscoveryContext discoveryContext;
        private IMessageLogger messageLogger;

        protected void Initialize(IDiscoveryContext discoveryContext, IMessageLogger messageLogger)
        {
            this.discoveryContext = discoveryContext;
            this.messageLogger = messageLogger;
            Log = new MessageLogger(messageLogger);
        }

        protected MessageLogger Log { get; private set; }
        internal class MessageLogger
        {
            private IMessageLogger messageLogger;

            public MessageLogger(IMessageLogger messageLogger)
            {
                this.messageLogger = messageLogger;
            }

            public void Informational(string message)
            {
                messageLogger.SendMessage(TestMessageLevel.Informational, message);
            }

            public void Warning(string message)
            {
                messageLogger.SendMessage(TestMessageLevel.Warning, message);
            }

            public void Error(string message)
            {
                messageLogger.SendMessage(TestMessageLevel.Error, message);
            }
        }
    }
}