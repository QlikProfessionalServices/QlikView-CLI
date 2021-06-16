using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentFolder")]
    public class NewQVDocumentFolder : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentFolder documentfolder;
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderAdministrators Administrators = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderAdministrators();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderGeneral General = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderGeneral();
        [Parameter]
        public System.Guid ID = Guid.NewGuid();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderScope Scope = default(QlikView_CLI.QMSAPI.DocumentFolderScope);
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderServices Services = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderServices();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentfolder = new QlikView_CLI.QMSAPI.DocumentFolder() { Administrators = Administrators, General = General, ID = ID, Scope = Scope, Services = Services };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentfolder);
        }
    }
}
