using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsData.Import, "QVDocumentTask")]
    public class ImportQVDocumentTask : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public Guid Remotedocumenttaskid;
        [Parameter]
        public Guid Destinationqdsid;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentNode Destinationdocument;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Connection.client.ImportDocumentTask(Remoteqmsid, Remotedocumenttaskid, Destinationqdsid, Destinationdocument);

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
            WriteObject(null);
        }

    }

}
