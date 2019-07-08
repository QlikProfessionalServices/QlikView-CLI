using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCALConfigurationUsageCALs")]
    public class NewQVCALConfigurationUsageCALs : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationUsageCALs calconfigurationusagecals;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedUsageCAL> Assignedcals = new List<QlikView_CLI.QMSAPI.AssignedUsageCAL>();
        [Parameter]
        public System.Int32 Available = new System.Int32();
        [Parameter]
        public System.Int32 Inlicense = new System.Int32();
        [Parameter]
        public System.Int32 Limit = new System.Int32();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            calconfigurationusagecals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationUsageCALs() { AssignedCALs = Assignedcals, Available = Available, InLicense = Inlicense, Limit = Limit };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(calconfigurationusagecals);
        }
    }
}
