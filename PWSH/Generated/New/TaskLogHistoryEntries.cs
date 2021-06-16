using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskLogHistoryEntries")]
    public class NewQVTaskLogHistoryEntries : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskLogHistoryEntries taskloghistoryentries;
        [Parameter]
        public System.String Date;
        [Parameter]
        public System.Guid Logid;
        [Parameter]
        public System.String Time;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskloghistoryentries = new QlikView_CLI.QMSAPI.TaskLogHistoryEntries() { Date = Date, LogId = Logid, Time = Time };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskloghistoryentries);
        }
    }
}
