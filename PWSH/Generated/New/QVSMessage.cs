using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVQVSMessage")]
    public class NewQVQVSMessage : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.QVSMessage qvsmessage;
        [Parameter]
        public List<System.String> Subtexts = new List<System.String>();
        [Parameter]
        public System.String Text;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            qvsmessage = new QlikView_CLI.QMSAPI.QVSMessage() { SubTexts = Subtexts, Text = Text };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(qvsmessage);
        }
    }
}
