using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDefaultDocumentTask")]
    public class NewQVDefaultDocumentTask : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentNode Document;
        private QlikView_CLI.QMSAPI.DocumentTask Documenttask;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == default)
            {
                qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qdsID)
                {
                    Documenttask = Connection.client.CreateDefaultDocumentTask(obj, Document);
                }

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
