using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVRemoteDocumentTask")]
    public class GetQVRemoteDocumentTask : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public Guid Taskid;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentTaskScope Scope;
        private QlikView_CLI.QMSAPI.DocumentTask Documenttask;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Documenttask = Connection.client.RemoteGetDocumentTask(Remoteqmsid, Taskid, Scope);

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
            WriteObject(Documenttask);
        }

    }

}
