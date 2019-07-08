using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVTaskStatus")]
    public class GetQVTaskStatus : PSClient
    {

        [Parameter]
        public Guid Taskid;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskStatusScope Scope;
        private QlikView_CLI.QMSAPI.TaskStatus Taskstatus;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Taskstatus = Connection.client.GetTaskStatus(Taskid, Scope);

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
