using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLicenseDefinition")]
    public class NewQVLicenseDefinition : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LicenseDefinition licensedefinition;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.LicenseDefinitionAllotment> Allotments = new List<QlikView_CLI.QMSAPI.LicenseDefinitionAllotment>();
        [Parameter]
        public System.Boolean Blacklisted = new System.Boolean();
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Feature> Features = new List<QlikView_CLI.QMSAPI.Feature>();
        [Parameter]
        public System.String Licensenumber;
        [Parameter]
        public System.String Valid;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            licensedefinition = new QlikView_CLI.QMSAPI.LicenseDefinition() { allotments = Allotments, blacklisted = Blacklisted, features = Features, licenseNumber = Licensenumber, valid = Valid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(licensedefinition);
        }
    }
}
