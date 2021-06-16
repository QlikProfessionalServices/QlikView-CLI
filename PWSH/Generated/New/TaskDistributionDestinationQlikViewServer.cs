using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributionDestinationQlikViewServer")]
    public class NewQVTaskDistributionDestinationQlikViewServer : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationQlikViewServer taskdistributiondestinationqlikviewserver;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Mount;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributiondestinationqlikviewserver = new QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationQlikViewServer() { ID = ID, Mount = Mount, Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributiondestinationqlikviewserver);
        }
    }
}
