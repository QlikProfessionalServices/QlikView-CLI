using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVEDXStatus")]
    public class NewQVEDXStatus : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.EDXStatus edxstatus;
        [Parameter]
        public System.String Category;
        [Parameter]
        public System.String Documentpath;
        [Parameter]
        public System.Guid Execid;
        [Parameter]
        public System.String Finishtime;
        [Parameter]
        public System.String Logfilefullpath;
        [Parameter]
        public System.Guid Qdsid;
        [Parameter]
        public System.String Starttime;
        [Parameter]
        public System.String Summary;
        [Parameter]
        public System.Guid Taskid;
        [Parameter]
        public System.String Taskname;
        [Parameter]
        public QlikView_CLI.QMSAPI.EDXTaskStartResult Taskstartresult = default(QlikView_CLI.QMSAPI.EDXTaskStartResult);
        [Parameter]
        public System.Int32 Taskstartresultcode = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusValue Taskstatus = default(QlikView_CLI.QMSAPI.TaskStatusValue);
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskType Tasktype = default(QlikView_CLI.QMSAPI.TaskType);
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskExecutionItem> Triggeredtasksid = new List<QlikView_CLI.QMSAPI.TaskExecutionItem>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            edxstatus = new QlikView_CLI.QMSAPI.EDXStatus() { Category = Category, DocumentPath = Documentpath, ExecId = Execid, FinishTime = Finishtime, LogFileFullPath = Logfilefullpath, QdsId = Qdsid, StartTime = Starttime, Summary = Summary, TaskId = Taskid, TaskName = Taskname, TaskStartResult = Taskstartresult, TaskStartResultCode = Taskstartresultcode, TaskStatus = Taskstatus, TaskType = Tasktype, TriggeredTasksId = Triggeredtasksid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(edxstatus);
        }
    }
}
