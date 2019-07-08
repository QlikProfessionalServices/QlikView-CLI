using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsData.Save, "QVNewLicense")]
    public class SaveQVNewLicense : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.License License;
        [Parameter]
        public Guid Serviceid;
        [Parameter]
        public string Licenseserver;
        private QlikView_CLI.QMSAPI.LicenseDefinition Licensedefinition;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Licensedefinition = Connection.client.SaveNewLicense(License, Serviceid, Licenseserver);

            }
            catch (System.Exception e)
            {
                var errorRecord = new ErrorRecord(e, e.Source, ErrorCategory.NotSpecified, Connection.client);
                WriteError(errorRecord);
            }

        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            WriteObject(Licensedefinition);
        }

    }

}
