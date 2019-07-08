using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVQVSSettings")]
    public class GetQVQVSSettings : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.QVSSettingsScope Scope;
        private QlikView_CLI.QMSAPI.QVSSettings Qvssettings;

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qvsID == null)
            {
                qvsID = Connection.QlikViewWebServer.Select(x => x.ID).ToArray();
            }

        }

        protected override void ProcessRecord()
        {
            try
            {
                foreach (Guid obj in qvsID)
                {
                    Qvssettings = Connection.client.GetQVSSettings(obj, Scope);
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
            WriteObject(Qvssettings);
        }

    }

}
