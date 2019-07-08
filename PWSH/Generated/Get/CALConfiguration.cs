using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVCALConfiguration")]
    public class GetQVCALConfiguration : PSClient
    {
        [Parameter]
        public Guid[] qvsID;

        [Parameter]
        public QlikView_CLI.QMSAPI.CALConfigurationScope Scope;
        private QlikView_CLI.QMSAPI.CALConfiguration Calconfiguration;

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
                    Calconfiguration = Connection.client.GetCALConfiguration(obj, Scope);
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
            WriteObject(Calconfiguration);
        }

    }

}
