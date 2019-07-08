using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVInterval")]
    public class NewQVInterval : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskStatusFilter.Interval interval;
        [Parameter]
        public System.DateTime From = new System.DateTime();
        [Parameter]
        public System.DateTime To = new System.DateTime();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            interval = new QlikView_CLI.QMSAPI.TaskStatusFilter.Interval() { From = From, To = To };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(interval);
        }
    }
}
