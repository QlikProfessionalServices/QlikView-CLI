using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVRemoteServices")]
    public class GetQVRemoteServices : PSClient
    {

        [Parameter]
        public Guid Remoteqmsid;
        [Parameter]
        public QlikView_CLI.QMSAPI.ServiceTypes Servicetypes;
        private System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServiceInfo> Serviceinfo = new System.Collections.Generic.List<QlikView_CLI.QMSAPI.ServiceInfo>();

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

        }

        protected override void ProcessRecord()
        {
            try
            {
                Serviceinfo = Connection.client.RemoteGetServices(Remoteqmsid, Servicetypes);

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
            WriteObject(Serviceinfo);
        }

    }

}
