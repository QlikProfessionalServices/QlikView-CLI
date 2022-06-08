using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDocumentTask")]
    public class GetQVDocumentTask : PSClient
    {

        [Parameter]
        public Guid Documenttaskid;
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
                Documenttask = Connection.client.GetDocumentTask(Documenttaskid, Scope);

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
