using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskEventTrigger")]
    public class NewQVTaskEventTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskEventTrigger taskeventtrigger;
        [Parameter]
        public System.Guid Taskid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskeventtrigger = new QlikView_CLI.QMSAPI.TaskEventTrigger() { TaskID = Taskid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskeventtrigger);
        }
    }
}
