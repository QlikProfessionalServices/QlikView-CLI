using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVScheduleTrigger")]
    public class NewQVScheduleTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.ScheduleTrigger scheduletrigger;
        [Parameter]
        public System.DateTime Startat = new System.DateTime();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            scheduletrigger = new QlikView_CLI.QMSAPI.ScheduleTrigger() { StartAt = Startat };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(scheduletrigger);
        }
    }
}
