using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCALConfigurationDocumentCALs")]
    public class NewQVCALConfigurationDocumentCALs : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationDocumentCALs calconfigurationdocumentcals;
        [Parameter]
        public System.Int32 Assigned = new System.Int32();
        [Parameter]
        public System.Int32 Inlicense = new System.Int32();
        [Parameter]
        public System.Int32 Limit = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            calconfigurationdocumentcals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationDocumentCALs() { Assigned = Assigned, InLicense = Inlicense, Limit = Limit };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(calconfigurationdocumentcals);
        }
    }
}
