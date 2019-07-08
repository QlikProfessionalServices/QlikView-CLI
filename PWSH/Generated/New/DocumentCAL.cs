using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentCAL")]
    public class NewQVDocumentCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentCAL documentcal;
        [Parameter]
        public System.String Documentname;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentcal = new QlikView_CLI.QMSAPI.DocumentCAL() { DocumentName = Documentname };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentcal);
        }
    }
}
