using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using QlikView_CLI.QMSAPI;

namespace QlikView_CLI.PWSH
{
    [Cmdlet(VerbsCommon.Get, "QVServices")]
    public class GetQVServices : PSClient
    {

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
                Serviceinfo = Connection.client.GetServices(Servicetypes);

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
