using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVServiceStatuses")]
    public class GetQVServiceStatuses : PSClient
    {

        [Parameter]
        public System.Collections.Generic.List<Guid> Serviceids;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServiceStatus> Servicestatus = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServiceStatus>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Servicestatus = Connection.client.GetServiceStatuses(Serviceids);

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
            WriteObject(Servicestatus);
        }

    }

}
