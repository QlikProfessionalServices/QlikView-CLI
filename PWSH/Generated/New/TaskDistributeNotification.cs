using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskDistributeNotification")]
    public class NewQVTaskDistributeNotification : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeNotification taskdistributenotification;
        [Parameter]
        public System.Boolean Sendnotificationemail = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskdistributenotification = new QlikView_CLI.QMSAPI.DocumentTask.TaskDistribute.TaskDistributeNotification() { SendNotificationEmail = Sendnotificationemail };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskdistributenotification);
        }
    }
}
