using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatusGeneral")]
    public class NewQVTaskStatusGeneral : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatus.TaskStatusGeneral taskstatusgeneral;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusValue Status = default(QlikView_CLI.QMSAPI.TaskStatusValue);
        [Parameter]
        public System.String Taskname;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskType Tasktype = default(QlikView_CLI.QMSAPI.TaskType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatusgeneral = new QlikView_CLI.QMSAPI.TaskStatus.TaskStatusGeneral() { Status = Status, TaskName = Taskname, TaskType = Tasktype };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatusgeneral);
        }
    }
}
