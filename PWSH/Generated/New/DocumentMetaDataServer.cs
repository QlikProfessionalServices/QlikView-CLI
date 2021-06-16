using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaDataServer")]
    public class NewQVDocumentMetaDataServer : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer documentmetadataserver;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer.DocumentMetaDataServerAccess Access = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer.DocumentMetaDataServerAccess();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer.DocumentMetaDataServerDocumentLoad> Documentload = new List<QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer.DocumentMetaDataServerDocumentLoad>();
        [Parameter]
        public System.Boolean Enableauditlogging = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.ServerDocumentLoadMode Serverdocumentloadmode = default(QlikView_CLI.QMSAPI.ServerDocumentLoadMode);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadataserver = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataServer() { Access = Access, DocumentLoad = Documentload, EnableAuditLogging = Enableauditlogging, ServerDocumentLoadMode = Serverdocumentloadmode };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadataserver);
        }
    }
}
