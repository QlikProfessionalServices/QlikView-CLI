using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVTaskStatuses")]
    public class GetQVTaskStatuses : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusFilter Filter;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusScope Scope;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskStatus> Taskstatus = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.TaskStatus>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Taskstatus = Connection.client.GetTaskStatuses(Filter, Scope);

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
            WriteObject(Taskstatus);
        }

    }

}
