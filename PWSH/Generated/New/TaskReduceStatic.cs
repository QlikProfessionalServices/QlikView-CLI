using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReduceStatic")]
    public class NewQVTaskReduceStatic : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceStatic taskreducestatic;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskReduction> Reductions = new List<QlikView_CLI.QMSAPI.TaskReduction>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreducestatic = new QlikView_CLI.QMSAPI.DocumentTask.TaskReduce.TaskReduceStatic() { Reductions = Reductions };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreducestatic);
        }
    }
}
