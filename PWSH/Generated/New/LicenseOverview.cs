using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLicenseOverview")]
    public class NewQVLicenseOverview : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.LicenseOverview licenseoverview;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Allotment> Allotments = new List<QlikView_CLI.QMSAPI.Allotment>();
        [Parameter]
        public System.Boolean Blacklisted = new System.Boolean();
        [Parameter]
        public System.String Errormessage;
        [Parameter]
        public System.String Licensekey;
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
            licenseoverview = new QlikView_CLI.QMSAPI.LicenseOverview() { Allotments = Allotments, BlackListed = Blacklisted, ErrorMessage = Errormessage, LicenseKey = Licensekey, LicenseNumber = Licensenumber, Valid = Valid };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(licenseoverview);
        }
    }
}
