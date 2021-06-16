using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatus")]
    public class NewQVTaskStatus : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatus taskstatus;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatus.TaskStatusExtended Extended = new QlikView_CLI.QMSAPI.TaskStatus.TaskStatusExtended();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatus.TaskStatusGeneral General = new QlikView_CLI.QMSAPI.TaskStatus.TaskStatusGeneral();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusScope Scope = default(QlikView_CLI.QMSAPI.TaskStatusScope);
        [Parameter]
        public System.Guid Taskid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatus = new QlikView_CLI.QMSAPI.TaskStatus() { Extended = Extended, General = General, Scope = Scope, TaskID = Taskid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatus);
        }
    }
}
