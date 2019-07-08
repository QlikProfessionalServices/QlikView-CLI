using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSPerformanceCPU")]
    public class NewQVQVSPerformanceCPU : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceCPU qvsperformancecpu;
        [Parameter]
        public List<System.Boolean> Affinity = new List<System.Boolean>();
        [Parameter]
        public System.Double Throttle = new System.Double();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsperformancecpu = new QlikView_CLI.QMSAPI.QVSSettings.QVSPerformance.QVSPerformanceCPU() { Affinity = Affinity, Throttle = Throttle };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsperformancecpu);
        }
    }
}
