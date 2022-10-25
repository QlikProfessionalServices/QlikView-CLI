using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQVSLicenseInfo")]
    public class GetQVQVSLicenseInfo : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        private QlikView_CLI.QMSAPI.LicenseModel Licensemodel;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == default)
            {
                qvsID = Connection.QlikViewServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    Licensemodel = Connection.client.GetQVSLicenseInfo(obj);
                }

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
            WriteObject(Licensemodel);
        }

    }

}
