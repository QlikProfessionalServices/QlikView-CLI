using System;
using System.Collections.Generic;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;
namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.New, "QVLicense")]
    public class NewQVLicense : PSCmdlet
    {
        private QlikView_CLI.QMSAPI.License license;
        [Parameter]
        public System.String Control;
        [Parameter]
        public System.String Corporation;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.LicenseFeature> Features = new List<QlikView_CLI.QMSAPI.LicenseFeature>();
        [Parameter]
        public System.String Leffile;
        [Parameter]
        public System.Boolean Lefok = new System.Boolean();
        [Parameter]
        public System.String Licensedefinition;
        [Parameter]
        public QlikView_CLI.QMSAPI.LicenseType Licensetype = default(QlikView_CLI.QMSAPI.LicenseType);
        [Parameter]
        public System.String Name;
        [Parameter]
        public List<QlikView_CLI.QMSAPI.Feature> Nxlicensefeatures = new List<QlikView_CLI.QMSAPI.Feature>();
        [Parameter]
        public System.String Serial;
        [Parameter]
        public System.String Signedkey;
        [Parameter]
        public System.Boolean Usesignedkey = new System.Boolean();


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            license = new QlikView_CLI.QMSAPI.License() { Control = Control, Corporation = Corporation, Features = Features, LEFFile = Leffile, LEFOk = Lefok, LicenseDefinition = Licensedefinition, LicenseType = Licensetype, Name = Name, NxLicenseFeatures = Nxlicensefeatures, Serial = Serial, SignedKey = Signedkey, UseSignedKey = Usesignedkey };
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(license);
        }
    }
}
