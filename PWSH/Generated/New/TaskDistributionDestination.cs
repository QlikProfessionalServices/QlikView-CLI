using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributionDestination")]
    public class NewQVTaskDistributionDestination : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskDistributionDestination taskdistributiondestination;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationFolder Folder = new QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationFolder();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationQlikViewServer Qlikviewserver = new QlikView_CLI.QMSAPI.TaskDistributionDestination.TaskDistributionDestinationQlikViewServer();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskDistributionDestinationType Type = default(QlikView_CLI.QMSAPI.TaskDistributionDestinationType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributiondestination = new QlikView_CLI.QMSAPI.TaskDistributionDestination() { Folder = Folder, QlikViewServer = Qlikviewserver, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributiondestination);
        }
    }
}
