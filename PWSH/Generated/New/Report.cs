using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVReport")]
    public class NewQVReport : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.Report report;
        [Parameter]
        public System.String ID;
        [Parameter]
        public System.String Name;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            report = new QlikView_CLI.QMSAPI.Report() { ID = ID, Name = Name };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(report);
        }
    }
}
