using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSFolders")]
    public class NewQVQVSFolders : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSFolders qvsfolders;
        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettings.QVSFolders.QVSFoldersSystem System = new QlikView_CLI.QMSAPI.QVSSettings.QVSFolders.QVSFoldersSystem();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.QVSFolderAdministrator> Userdocumentadministrators = new List<QlikView_CLI.QMSAPI.QVSFolderAdministrator>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.QVSMount> Userdocumentmounts = new List<QlikView_CLI.QMSAPI.QVSMount>();
        [Parameter]
        public System.String Userdocumentrootfolder;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsfolders = new QlikView_CLI.QMSAPI.QVSSettings.QVSFolders() { System = System, UserDocumentAdministrators = Userdocumentadministrators, UserDocumentMounts = Userdocumentmounts, UserDocumentRootFolder = Userdocumentrootfolder };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsfolders);
        }
    }
}
