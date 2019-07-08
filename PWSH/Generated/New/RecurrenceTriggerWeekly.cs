using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVRecurrenceTriggerWeekly")]
    public class NewQVRecurrenceTriggerWeekly : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerWeekly recurrencetriggerweekly;
        [Parameter]
        public List<System.DayOfWeek> Dayofweekconstraints = new List<System.DayOfWeek>();
        [Parameter]
        public System.Int32 Recurevery = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            recurrencetriggerweekly = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerWeekly() { DayOfWeekConstraints = Dayofweekconstraints, RecurEvery = Recurevery };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(recurrencetriggerweekly);
        }
    }
}
