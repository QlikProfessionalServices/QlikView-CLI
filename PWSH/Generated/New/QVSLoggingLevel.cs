using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSLoggingLevel")]
    public class NewQVQVSLoggingLevel : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSLogging.QVSLoggingLevel qvslogginglevel;
        [Parameter]
        public System.Boolean Enableeventlogging = new System.Boolean();
        [Parameter]
        public System.Boolean Enableperformancelogging = new System.Boolean();
        [Parameter]
        public System.Boolean Enablesessionlogging = new System.Boolean();
        [Parameter]
        public System.Int32 Performancelogginginterval = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvslogginglevel = new QlikView_CLI.QMSAPI.QVSSettings.QVSLogging.QVSLoggingLevel() { EnableEventLogging = Enableeventlogging, EnablePerformanceLogging = Enableperformancelogging, EnableSessionLogging = Enablesessionlogging, PerformanceLoggingInterval = Performancelogginginterval };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvslogginglevel);
        }
    }
}
