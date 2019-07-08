using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskStatusFilter")]
    public class NewQVTaskStatusFilter : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusFilter taskstatusfilter;
        [Parameter]
        public List<System.String> Categories = new List<System.String>();
        [Parameter]
        public List<System.String> Distributiongroups = new List<System.String>();
        [Parameter]
        public QlikView_CLI.QMSAPI.EnabledState Enabledstate = default(QlikView_CLI.QMSAPI.EnabledState);
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusFilter.LastExecutionInterval Lastexecution = new QlikView_CLI.QMSAPI.TaskStatusFilter.LastExecutionInterval();
        [Parameter]
        public List<System.Guid> Qdsids = new List<System.Guid>();
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusFilter.ScheduleInterval Schedule = new QlikView_CLI.QMSAPI.TaskStatusFilter.ScheduleInterval();
        [Parameter]
        public List<System.Guid> Taskids = new List<System.Guid>();
        [Parameter]
        public System.String Taskname;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskStatusValue> Taskstatuses = new List<QlikView_CLI.QMSAPI.TaskStatusValue>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.TaskType> Tasktypes = new List<QlikView_CLI.QMSAPI.TaskType>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskstatusfilter = new QlikView_CLI.QMSAPI.TaskStatusFilter() { Categories = Categories, DistributionGroups = Distributiongroups, EnabledState = Enabledstate, LastExecution = Lastexecution, QDSIds = Qdsids, Schedule = Schedule, TaskIds = Taskids, TaskName = Taskname, TaskStatuses = Taskstatuses, TaskTypes = Tasktypes };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskstatusfilter);
        }
    }
}
