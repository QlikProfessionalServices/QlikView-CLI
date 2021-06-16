using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatusNode")]
    public class NewQVTaskStatusNode : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusNode taskstatusnode;
        [Parameter]
        public System.Int32 Failcount = new System.Int32();
        [Parameter]
        public System.Boolean Haschildren = new System.Boolean();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.Guid Parentid;
        [Parameter]
        public System.Guid Requestid;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusNodeType Roottype = default(QlikView_CLI.QMSAPI.TaskStatusNodeType);
        [Parameter]
        public System.Int32 Runcount = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusValue Status = default(QlikView_CLI.QMSAPI.TaskStatusValue);
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatus Taskstatus = new QlikView_CLI.QMSAPI.TaskStatus();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusNodeType Type = default(QlikView_CLI.QMSAPI.TaskStatusNodeType);
        [Parameter]
        public System.Int32 Warningcount = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatusnode = new QlikView_CLI.QMSAPI.TaskStatusNode() { FailCount = Failcount, HasChildren = Haschildren, ID = ID, Name = Name, ParentID = Parentid, RequestID = Requestid, RootType = Roottype, RunCount = Runcount, Status = Status, TaskStatus = Taskstatus, Type = Type, WarningCount = Warningcount };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatusnode);
        }
    }
}
