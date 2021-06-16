using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVUnit")]
    public class NewQVUnit : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Unit unit;
        [Parameter]
        public System.Int32 Count = new System.Int32();
        [Parameter]
        public System.String Report;
        [Parameter]
        public System.String Valid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            unit = new QlikView_CLI.QMSAPI.Unit() { Count = Count, Report = Report, Valid = Valid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(unit);
        }
    }
}
