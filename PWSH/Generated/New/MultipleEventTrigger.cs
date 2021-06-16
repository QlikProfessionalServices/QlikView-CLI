using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVMultipleEventTrigger")]
    public class NewQVMultipleEventTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.MultipleEventTrigger multipleeventtrigger;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Trigger> Subtriggers = new List<QlikView_CLI.QMSAPI.Trigger>();
        [Parameter]
        public System.Int32 Timeconstraint = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            multipleeventtrigger = new QlikView_CLI.QMSAPI.MultipleEventTrigger() { SubTriggers = Subtriggers, TimeConstraint = Timeconstraint };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(multipleeventtrigger);
        }
    }
}
