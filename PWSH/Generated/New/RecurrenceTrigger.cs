using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVRecurrenceTrigger")]
    public class NewQVRecurrenceTrigger : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.RecurrenceTrigger recurrencetrigger;
        [Parameter]
        public QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerContinuous Continuous = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerContinuous();
        [Parameter]
        public QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerDaily Daily = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerDaily();
        [Parameter]
        public System.DateTime Expireat = new System.DateTime();
        [Parameter]
        public QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerHourly Hourly = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerHourly();
        [Parameter]
        public System.Int32 Maxoccurrences = new System.Int32();
        [Parameter]
        public QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerMonthly Monthly = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerMonthly();
        [Parameter]
        public QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerWeekly Weekly = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerWeekly();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            recurrencetrigger = new QlikView_CLI.QMSAPI.RecurrenceTrigger() { Continuous = Continuous, Daily = Daily, ExpireAt = Expireat, Hourly = Hourly, MaxOccurrences = Maxoccurrences, Monthly = Monthly, Weekly = Weekly };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(recurrencetrigger);
        }
    }
}
