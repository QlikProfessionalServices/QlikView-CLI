using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsData.Save, "QVNewLicenseEx")]
    public class SaveQVNewLicenseEx : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.License License;
        private QlikView_CLI.QMSAPI.LicenseDefinition Licensedefinition;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Licensedefinition = Connection.client.SaveNewLicenseEx(License);

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
