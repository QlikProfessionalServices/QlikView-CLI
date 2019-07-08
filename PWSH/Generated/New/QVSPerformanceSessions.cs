using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSPerformanceSessions")]
    public class NewQVQVSPerformanceSessions : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceSessions qvsperformancesessions;
        [Parameter]
        public System.Int32 Concurrentsessionstimeout = new System.Int32();
        [Parameter]
        public System.Int32 Maxconcurrentsessions = new System.Int32();
        [Parameter]
        public System.Int32 Maxinactivesessiontime = new System.Int32();
        [Parameter]
        public System.Int32 Maxtotalsessiontime = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsperformancesessions = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceSessions() { ConcurrentSessionsTimeout = Concurrentsessionstimeout, MaxConcurrentSessions = Maxconcurrentsessions, MaxInactiveSessionTime = Maxinactivesessiontime, MaxTotalSessionTime = Maxtotalsessiontime };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsperformancesessions);
        }
    }
}
