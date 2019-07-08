using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSFoldersSystem")]
    public class NewQVQVSFoldersSystem : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSSettings.QVSFolders.QVSFoldersSystem qvsfolderssystem;
        [Parameter]
        public System.String Exporttemporaryfolder;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsfolderssystem = new QlikView_CLI.QMSAPI.QVSSettings.QVSFolders.QVSFoldersSystem() { ExportTemporaryFolder = Exporttemporaryfolder };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsfolderssystem);
        }
    }
}
