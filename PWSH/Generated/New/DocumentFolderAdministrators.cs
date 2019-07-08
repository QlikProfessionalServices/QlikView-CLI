using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentFolderAdministrators")]
    public class NewQVDocumentFolderAdministrators : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderAdministrators documentfolderadministrators;
        [Parameter]
        public List<System.String> Usernames = new List<System.String>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentfolderadministrators = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderAdministrators() { UserNames = Usernames };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentfolderadministrators);
        }
    }
}
