using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsLifecycle.Stop, "QVDistributionService")]
    public class StopQVDistributionService : PSClient
    {
        [Parameter]
        public Guid[] qdsID;

        [Parameter]
        public Guid Nodeid;
        [Parameter]
        public string Address;


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            if (qdsID == null)
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
                    Connection.client.ShutdownDistributionService(obj, Nodeid, Address);
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
            WriteObject(null);
        }

    }

}
