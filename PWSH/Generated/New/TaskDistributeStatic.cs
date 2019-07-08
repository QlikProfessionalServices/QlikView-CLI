using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeStatic")]
    public class NewQVTaskDistributeStatic : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeStatic taskdistributestatic;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskDistributionEntry> Distributionentries = new List<QlikView_CLI.QMSAPI.TaskDistributionEntry>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributestatic = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeStatic() { DistributionEntries = Distributionentries };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributestatic);
        }
    }
}
