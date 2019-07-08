using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLicenseFeature")]
    public class NewQVLicenseFeature : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LicenseFeature licensefeature;
        [Parameter]
        public System.String Name;
        [Parameter]
        public System.String Value;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            licensefeature = new QlikView_CLI.QMSAPI.LicenseFeature() { Name = Name, Value = Value };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(licensefeature);
        }
    }
}
