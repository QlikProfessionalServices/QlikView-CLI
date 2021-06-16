using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVRecurrenceTriggerDaily")]
    public class NewQVRecurrenceTriggerDaily : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerDaily recurrencetriggerdaily;
        [Parameter]
        public System.Int32 Recurevery = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            recurrencetriggerdaily = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerDaily() { RecurEvery = Recurevery };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(recurrencetriggerdaily);
        }
    }
}
