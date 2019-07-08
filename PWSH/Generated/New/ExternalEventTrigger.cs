using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVExternalEventTrigger")]
    public class NewQVExternalEventTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ExternalEventTrigger externaleventtrigger;
        [Parameter]
        public System.String Password;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            externaleventtrigger = new QlikView_CLI.QMSAPI.ExternalEventTrigger() { Password = Password };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(externaleventtrigger);
        }
    }
}
