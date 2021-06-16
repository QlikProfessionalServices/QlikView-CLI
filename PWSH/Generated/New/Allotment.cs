using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVAllotment")]
    public class NewQVAllotment : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Allotment allotment;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.Int32 Overage = new System.Int32();
        [Parameter]
        public System.Int32 Units = new System.Int32();
        [Parameter]
        public System.Int32 Unitsused = new System.Int32();
        [Parameter]
        public System.String Usageclass;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            allotment = new QlikView_CLI.QMSAPI.Allotment() { Name = Name, Overage = Overage, Units = Units, UnitsUsed = Unitsused, UsageClass = Usageclass };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(allotment);
        }
    }
}
