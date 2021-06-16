using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaDataAuthorization")]
    public class NewQVDocumentMetaDataAuthorization : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataAuthorization documentmetadataauthorization;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentAccessEntry> Access = new List<QlikView_CLI.QMSAPI.DocumentAccessEntry>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadataauthorization = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataAuthorization() { Access = Access };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadataauthorization);
        }
    }
}
