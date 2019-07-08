using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVRecurrenceTriggerContinuous")]
    public class NewQVRecurrenceTriggerContinuous : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerContinuous recurrencetriggercontinuous;
        [Parameter]
        public List<System.DayOfWeek> Dayofweekconstraints = new List<System.DayOfWeek>();
        [Parameter]
        public System.Int32 Recurevery = new System.Int32();
        [Parameter]
        public System.DateTime Timeconstraintfrom = new System.DateTime();
        [Parameter]
        public System.DateTime Timeconstraintto = new System.DateTime();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            recurrencetriggercontinuous = new QlikView_CLI.QMSAPI.RecurrenceTrigger.RecurrenceTriggerContinuous() { DayOfWeekConstraints = Dayofweekconstraints, RecurEvery = Recurevery, TimeConstraintFrom = Timeconstraintfrom, TimeConstraintTo = Timeconstraintto };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(recurrencetriggercontinuous);
        }
    }
}
