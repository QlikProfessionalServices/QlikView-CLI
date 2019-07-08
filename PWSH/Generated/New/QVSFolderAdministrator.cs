using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSFolderAdministrator")]
    public class NewQVQVSFolderAdministrator : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSFolderAdministrator qvsfolderadministrator;
        [Parameter]
        public System.Guid Folderid;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSUserDocumentFolderType Foldertype = default(QlikView_CLI.QMSAPI.QVSUserDocumentFolderType);
        [Parameter]
        public System.String Username;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsfolderadministrator = new QlikView_CLI.QMSAPI.QVSFolderAdministrator() { FolderID = Folderid, FolderType = Foldertype, UserName = Username };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsfolderadministrator);
        }
    }
}
