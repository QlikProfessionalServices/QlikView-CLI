using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVProvision")]
    public class NewQVProvision : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Provision provision;
        [Parameter]
        public System.String Accesstype;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            provision = new QlikView_CLI.QMSAPI.Provision() { AccessType = Accesstype };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(provision);
        }
    }
}
