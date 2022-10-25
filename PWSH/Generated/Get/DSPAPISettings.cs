using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVDSPAPISettings")]
    public class GetQVDSPAPISettings : PSClient
    {
        [Parameter]
        public Guid[] dscID;

        [Parameter]
        public QlikView_CLI.QMSAPI.DSPType Dsptype;
        private QlikView_CLI.QMSAPI.DSPSettings Dspsettings;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (dscID == default)
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
                    Dspsettings = Connection.client.GetDSPAPISettings(obj, Dsptype);
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
            WriteObject(Dspsettings);
        }

    }

}
