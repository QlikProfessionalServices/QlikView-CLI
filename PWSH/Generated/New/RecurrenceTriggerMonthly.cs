using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVRecurrenceTriggerMonthly")]
    public class NewQVRecurrenceTriggerMonthly : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerMonthly recurrencetriggermonthly;
        [Parameter]
        public List<System.Int32> Dayconstraints = new List<System.Int32>();
        [Parameter]
        public List<System.DayOfWeek> Dayofweekconstraints = new List<System.DayOfWeek>();
        [Parameter]
        public List<System.Int32> Months = new List<System.Int32>();
        [Parameter]
        public List<System.Int32> Occurrences = new List<System.Int32>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            recurrencetriggermonthly = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerMonthly() { DayConstraints = Dayconstraints, DayOfWeekConstraints = Dayofweekconstraints, Months = Months, Occurrences = Occurrences };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(recurrencetriggermonthly);
        }
    }
}
