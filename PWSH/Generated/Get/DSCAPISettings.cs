using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDSCAPISettings")]
    public class GetQVDSCAPISettings : PSClient
    {
        [Parameter]
        public Guid[] dscID;

        private QlikView_CLI.QMSAPI.DirectoryServiceConnectorAPISettings Directoryserviceconnectorapisettings;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (dscID == null)
            {
                dscID = Connection.QlikViewDirectoryServiceConnector.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in dscID)
                {
                    Directoryserviceconnectorapisettings = Connection.client.GetDSCAPISettings(obj);
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
            WriteObject(Directoryserviceconnectorapisettings);
        }

    }

}
