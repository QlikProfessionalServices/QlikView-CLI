using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVTaskReductionField")]
    public class NewQVTaskReductionField : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.TaskReduction.TaskReductionField taskreductionfield;
        [Parameter]
        public System.Boolean Isnumeric = new System.Boolean();
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.Double Number = new System.Double();
        [Parameter]
        public System.String Value;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            taskreductionfield = new QlikView_CLI.QMSAPI.TaskReduction.TaskReductionField() { IsNumeric = Isnumeric, Name = Name, Number = Number, Value = Value };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(taskreductionfield);
        }
    }
}
