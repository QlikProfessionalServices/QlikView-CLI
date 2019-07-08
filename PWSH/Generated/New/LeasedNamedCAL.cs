using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLeasedNamedCAL")]
    public class NewQVLeasedNamedCAL : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LeasedNamedCAL leasednamedcal;
        [Parameter]
        public System.DateTime Leasedat = new System.DateTime();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            leasednamedcal = new QlikView_CLI.QMSAPI.LeasedNamedCAL() { LeasedAt = Leasedat };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(leasednamedcal);
        }
    }
}
