using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributionDestinationFolder")]
    public class NewQVTaskDistributionDestinationFolder : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationFolder taskdistributiondestinationfolder;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributiondestinationfolder = new QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationFolder() { Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributiondestinationfolder);
        }
    }
}
