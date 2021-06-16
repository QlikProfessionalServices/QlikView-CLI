using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentMetaDataCollaboration")]
    public class NewQVDocumentMetaDataCollaboration : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataCollaboration documentmetadatacollaboration;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentCollaborationCreationMode Creationmode = default(QlikView_CLI.QMSAPI.DocumentCollaborationCreationMode);
        [Parameter]
        public List<System.String> Creatorusernames = new List<System.String>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentmetadatacollaboration = new QlikView_CLI.QMSAPI.DocumentMetaData.DocumentMetaDataCollaboration() { CreationMode = Creationmode, CreatorUserNames = Creatorusernames };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentmetadatacollaboration);
        }
    }
}
