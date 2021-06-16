using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLicenseDefinitionAllotment")]
    public class NewQVLicenseDefinitionAllotment : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LicenseDefinitionAllotment licensedefinitionallotment;
        [Parameter]
        public System.Int32 Consumed = new System.Int32();
        [Parameter]
        public System.String Name;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Provision> Provisions = new List<QlikView_CLI.QMSAPI.Provision>();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Unit> Units = new List<QlikView_CLI.QMSAPI.Unit>();
        [Parameter]
        public QlikView_CLI.QMSAPI.Usage Usage = new QlikView_CLI.QMSAPI.Usage();
        [Parameter]
        public System.String Valid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            licensedefinitionallotment = new QlikView_CLI.QMSAPI.LicenseDefinitionAllotment() { Consumed = Consumed, Name = Name, Provisions = Provisions, Units = Units, Usage = Usage, Valid = Valid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(licensedefinitionallotment);
        }
    }
}
