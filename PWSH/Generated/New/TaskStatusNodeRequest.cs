using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatusNodeRequest")]
    public class NewQVTaskStatusNodeRequest : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusNodeRequest taskstatusnoderequest;
        [Parameter]
        public System.String Categoryname;
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusNodeType Roottype = default(QlikView_CLI.QMSAPI.TaskStatusNodeType);
        [Parameter]
        public System.Guid Taskid;
        [Parameter]
        public System.Boolean Useflattasklist = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatusnoderequest = new QlikView_CLI.QMSAPI.TaskStatusNodeRequest() { CategoryName = Categoryname, ID = ID, QDSID = QDSID, RootType = Roottype, TaskID = Taskid, UseFlatTaskList = Useflattasklist };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatusnoderequest);
        }
    }
}
