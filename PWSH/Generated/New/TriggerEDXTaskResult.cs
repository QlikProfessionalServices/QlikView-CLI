using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTriggerEDXTaskResult")]
    public class NewQVTriggerEDXTaskResult : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TriggerEDXTaskResult triggeredxtaskresult;
        [Parameter]
        public QlikView_CLI.QMSAPI.EDXTaskStartResult Edxtaskstartresult = default(QlikView_CLI.QMSAPI.EDXTaskStartResult);
        [Parameter]
        public System.Int32 Edxtaskstartresultcode = new System.Int32();
        [Parameter]
        public System.Guid Execid;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusValue Status = default(QlikView_CLI.QMSAPI.TaskStatusValue);
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskExecutionItem> Triggeredtasksid = new List<QlikView_CLI.QMSAPI.TaskExecutionItem>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            triggeredxtaskresult = new QlikView_CLI.QMSAPI.TriggerEDXTaskResult() { EDXTaskStartResult = Edxtaskstartresult, EDXTaskStartResultCode = Edxtaskstartresultcode, ExecId = Execid, Status = Status, TriggeredTasksId = Triggeredtasksid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(triggeredxtaskresult);
        }
    }
}
