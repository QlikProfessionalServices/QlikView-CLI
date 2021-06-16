using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSPerformance")]
    public class NewQVQVSPerformance : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance qvsperformance;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceCPU CPU = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceCPU();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceDocument Document = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceDocument();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceSessions Sessions = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceSessions();
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceWorkingSetMemory Workingsetmemory = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceWorkingSetMemory();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsperformance = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance() { CPU = CPU, Document = Document, Sessions = Sessions, WorkingSetMemory = Workingsetmemory };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsperformance);
        }
    }
}
