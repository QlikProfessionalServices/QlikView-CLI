using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSPerformanceWorkingSetMemory")]
    public class NewQVQVSPerformanceWorkingSetMemory : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceWorkingSetMemory qvsperformanceworkingsetmemory;
        [Parameter]
        public System.Int32 Highlimit = new System.Int32();
        [Parameter]
        public System.Int32 Lowlimit = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsperformanceworkingsetmemory = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceWorkingSetMemory() { HighLimit = Highlimit, LowLimit = Lowlimit };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsperformanceworkingsetmemory);
        }
    }
}
