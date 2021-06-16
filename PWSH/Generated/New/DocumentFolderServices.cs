using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentFolderServices")]
    public class NewQVDocumentFolderServices : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderServices documentfolderservices;
        [Parameter]
        public System.Guid QDSID;
        [Parameter]
        public System.Guid QVSID;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentfolderservices = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderServices() { QDSID = QDSID, QVSID = QVSID };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentfolderservices);
        }
    }
}
