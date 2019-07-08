using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentFolderGeneral")]
    public class NewQVDocumentFolderGeneral : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderGeneral documentfoldergeneral;
        [Parameter]
        public System.String Path;
        [Parameter]
        public System.Boolean Sendalertemailfordocumentadministrators = new System.Boolean();
        [Parameter]
        public QlikView_CLI.QMSAPI.DocumentFolderType Type = default(QlikView_CLI.QMSAPI.DocumentFolderType);


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentfoldergeneral = new QlikView_CLI.QMSAPI.DocumentFolder.DocumentFolderGeneral() { Path = Path, SendAlertEmailForDocumentAdministrators = Sendalertemailfordocumentadministrators, Type = Type };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentfoldergeneral);
        }
    }
}
