using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskTriggering")]
    public class NewQVTaskTriggering : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentTask.TaskTriggering tasktriggering;
        [Parameter]
        public System.UInt32 Executionattempts = new System.UInt32();
        [Parameter]
        public System.UInt32 Executiontimeout = new System.UInt32();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskInfo> Taskdependencies = new List<QlikView_CLI.QMSAPI.TaskInfo>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Trigger> Triggers = new List<QlikView_CLI.QMSAPI.Trigger>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            tasktriggering = new QlikView_CLI.QMSAPI.DocumentTask.TaskTriggering() { ExecutionAttempts = Executionattempts, ExecutionTimeout = Executiontimeout, TaskDependencies = Taskdependencies, Triggers = Triggers };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(tasktriggering);
        }
    }
}
