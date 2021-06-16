using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCALConfigurationSessionCALs")]
    public class NewQVCALConfigurationSessionCALs : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationSessionCALs calconfigurationsessioncals;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedSessionCAL> Assignedcals = new List<QlikView_CLI.QMSAPI.AssignedSessionCAL>();
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
            calconfigurationsessioncals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationSessionCALs() { AssignedCALs = Assignedcals, Available = Available, InLicense = Inlicense, Limit = Limit };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(calconfigurationsessioncals);
        }
    }
}
