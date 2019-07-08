using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVDocumentAttribute")]
    public class NewQVDocumentAttribute : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.DocumentAttribute documentattribute;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Value;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            documentattribute = new QlikView_CLI.QMSAPI.DocumentAttribute() { Name = Name, Value = Value };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(documentattribute);
        }
    }
}
