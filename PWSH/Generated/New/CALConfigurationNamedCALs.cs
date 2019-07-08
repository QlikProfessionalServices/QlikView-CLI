using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVCALConfigurationNamedCALs")]
    public class NewQVCALConfigurationNamedCALs : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationNamedCALs calconfigurationnamedcals;
        [Parameter]
        public System.Boolean Allowdynamicassignment = new System.Boolean();
        [Parameter]
        public System.Boolean Allowdynamicassignmentanalyzer = new System.Boolean();
        [Parameter]
        public System.Boolean Allowdynamicassignmentprofessional = new System.Boolean();
        [Parameter]
        public System.Boolean Allowlicenselease = new System.Boolean();
        [Parameter]
        public System.Int32 Assigned = new System.Int32();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedNamedCAL> Assignedcals = new List<QlikView_CLI.QMSAPI.AssignedNamedCAL>();
        [Parameter]
        public QlikView_CLI.QMSAPI.NamedCALIdentificationMode Identificationmode = default(QlikView_CLI.QMSAPI.NamedCALIdentificationMode);
        [Parameter]
        public System.Int32 Inlicense = new System.Int32();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.LeasedNamedCAL> Leasedcals = new List<QlikView_CLI.QMSAPI.LeasedNamedCAL>();
        [Parameter]
        public System.Int32 Limit = new System.Int32();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.AssignedNamedCAL> Removedassignedcals = new List<QlikView_CLI.QMSAPI.AssignedNamedCAL>();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            calconfigurationnamedcals = new QlikView_CLI.QMSAPI.CALConfiguration.CALConfigurationNamedCALs() { AllowDynamicAssignment = Allowdynamicassignment, AllowDynamicAssignmentAnalyzer = Allowdynamicassignmentanalyzer, AllowDynamicAssignmentProfessional = Allowdynamicassignmentprofessional, AllowLicenseLease = Allowlicenselease, Assigned = Assigned, AssignedCALs = Assignedcals, IdentificationMode = Identificationmode, InLicense = Inlicense, LeasedCALs = Leasedcals, Limit = Limit, RemovedAssignedCALs = Removedassignedcals };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(calconfigurationnamedcals);
        }
    }
}
