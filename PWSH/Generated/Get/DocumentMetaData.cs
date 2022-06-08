using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDocumentMetaData")]
    public class GetQVDocumentMetaData : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentNode Userdocument;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaDataScope Scope;
        private QlikView_CLI.QMSAPI.DocumentMetaData Documentmetadata;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Documentmetadata = Connection.client.GetDocumentMetaData(Userdocument, Scope);

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
            WriteObject(Documentmetadata);
        }

    }

}
