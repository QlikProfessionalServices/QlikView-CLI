using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVServiceUpdateStatus")]
    public class NewQVServiceUpdateStatus : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ServiceUpdateStatus serviceupdatestatus;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            serviceupdatestatus = new QlikView_CLI.QMSAPI.ServiceUpdateStatus() { };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(serviceupdatestatus);
        }
    }
}
