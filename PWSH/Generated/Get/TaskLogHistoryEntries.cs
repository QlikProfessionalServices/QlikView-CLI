using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVTaskLogHistoryEntries")]
    public class GetQVTaskLogHistoryEntries : PSClient
    {

        [Parameter]
        public Guid Taskid;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskLogHistoryEntries> Taskloghistoryentries = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskLogHistoryEntries>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Taskloghistoryentries = Connection.client.GetTaskLogHistoryEntries(Taskid);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Taskloghistoryentries);
        }

    }

}
