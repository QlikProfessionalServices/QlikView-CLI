using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVLicense")]
    public class GetQVLicense : PSClient
    {

        [Parameter]
        public QlikView_CLI.QMSAPI.LicenseType Licensetype;
        [Parameter]
        public Guid Serviceid;
        private QlikView_CLI.QMSAPI.License License;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                License = Connection.client.GetLicense(Licensetype, Serviceid);

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
            WriteObject(License);
        }

    }

}
