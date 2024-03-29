using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVLicenseOverview")]
    public class GetQVLicenseOverview : PSClient
    {

        private QlikView_CLI.QMSAPI.LicenseOverview Licenseoverview;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Licenseoverview = Connection.client.GetLicenseOverview();

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
            WriteObject(Licenseoverview);
        }

    }

}
