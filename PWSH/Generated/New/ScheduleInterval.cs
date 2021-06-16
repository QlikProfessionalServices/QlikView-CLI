using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVScheduleInterval")]
    public class NewQVScheduleInterval : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusFilter.ScheduleInterval scheduleinterval;
        [Parameter]
        public System.Boolean Includenotscheduled = new System.Boolean();
        [Parameter]
        public System.Boolean Includeonevent = new System.Boolean();
        [Parameter]
        public System.Boolean Includeonexternalevent = new System.Boolean();
        [Parameter]
        public System.Boolean Includeonmultipleevents = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            scheduleinterval = new QlikView_CLI.QMSAPI.TaskStatusFilter.ScheduleInterval() { IncludeNotScheduled = Includenotscheduled, IncludeOnEvent = Includeonevent, IncludeOnExternalEvent = Includeonexternalevent, IncludeOnMultipleEvents = Includeonmultipleevents };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(scheduleinterval);
        }
    }
}
