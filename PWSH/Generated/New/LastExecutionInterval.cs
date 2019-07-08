using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLastExecutionInterval")]
    public class NewQVLastExecutionInterval : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusFilter.LastExecutionInterval lastexecutioninterval;
        [Parameter]
        public System.Boolean Includenever = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            lastexecutioninterval = new QlikView_CLI.QMSAPI.TaskStatusFilter.LastExecutionInterval() { IncludeNever = Includenever };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(lastexecutioninterval);
        }
    }
}
