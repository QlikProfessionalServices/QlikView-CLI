using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributionEntry")]
    public class NewQVTaskDistributionEntry : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskDistributionEntry taskdistributionentry;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskDistributionDestination Destination = new QlikView_CLI.QMSAPI.TaskDistributionDestination();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DirectoryServiceObject> Recipients = new List<QlikView_CLI.QMSAPI.DirectoryServiceObject>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributionentry = new QlikView_CLI.QMSAPI.TaskDistributionEntry() { Destination = Destination, Recipients = Recipients };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributionentry);
        }
    }
}
