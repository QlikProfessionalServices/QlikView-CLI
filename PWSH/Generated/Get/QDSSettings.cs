using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQDSSettings")]
    public class GetQVQDSSettings : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QDSSettingsScope Scope;
        private QlikView_CLI.QMSAPI.QDSSettings Qdssettings;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == default)
            {
                qdsID = Connection.QlikViewDistributionService.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qdsID)
                {
                    Qdssettings = Connection.client.GetQDSSettings(obj, Scope);
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
            WriteObject(Qdssettings);
        }

    }

}
