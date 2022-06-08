using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Remove, "QVTask")]
    public class RemoveQVTask : PSClient
    {

        [Parameter]
        public Guid Taskid;
        [Parameter]
        public QlikView_CLI.QMSAPI.TaskType Tasktype;
        private bool Bool;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Bool = Connection.client.DeleteTask(Taskid, Tasktype);

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
            WriteObject(Bool);
        }

    }

}
