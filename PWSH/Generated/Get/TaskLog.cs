using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVTaskLog")]
    public class GetQVTaskLog : PSClient
    {

        [Parameter]
        public Guid Taskid;
        [Parameter]
        public Guid Logid;
        [Parameter]
        public int Maxrecords;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.LogFileEntry> Logfileentry = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.LogFileEntry>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Logfileentry = Connection.client.GetTaskLog(Taskid, Logid, Maxrecords);

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
            WriteObject(Logfileentry);
        }

    }

}
