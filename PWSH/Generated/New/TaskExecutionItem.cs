using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskExecutionItem")]
    public class NewQVTaskExecutionItem : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskExecutionItem taskexecutionitem;
        [Parameter]
        public System.Guid Execid;
        [Parameter]
        public System.Guid Taskid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskexecutionitem = new QlikView_CLI.QMSAPI.TaskExecutionItem() { ExecId = Execid, TaskId = Taskid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskexecutionitem);
        }
    }
}
