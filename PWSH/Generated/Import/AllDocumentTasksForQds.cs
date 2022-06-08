using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsData.Import, "QVAllDocumentTasksForQds")]
    public class ImportQVAllDocumentTasksForQds : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public Guid Remoteqdsid;
        [Parameter]
        public Guid Destinationqdsid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Connection.client.ImportAllDocumentTasksForQds(Remoteqmsid, Remoteqdsid, Destinationqdsid);

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
