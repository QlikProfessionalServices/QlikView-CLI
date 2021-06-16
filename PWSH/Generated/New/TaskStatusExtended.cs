using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatusExtended")]
    public class NewQVTaskStatusExtended : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatus.TaskStatusExtended taskstatusextended;
        [Parameter]
        public System.String Category;
        [Parameter]
        public System.String Distributiongroup;
        [Parameter]
        public System.String Documentpath;
        [Parameter]
        public System.String Finishedtime;
        [Parameter]
        public System.String Lastexecutedon;
        [Parameter]
        public System.String Lastlogmessages;
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public System.String Runningon;
        [Parameter]
        public System.String Starttime;
        [Parameter]
        public System.String Tasksummary;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatusextended = new QlikView_CLI.QMSAPI.TaskStatus.TaskStatusExtended() { Category = Category, DistributionGroup = Distributiongroup, DocumentPath = Documentpath, FinishedTime = Finishedtime, LastExecutedOn = Lastexecutedon, LastLogMessages = Lastlogmessages, QDSID = QDSID, RunningOn = Runningon, StartTime = Starttime, TaskSummary = Tasksummary };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatusextended);
        }
    }
}
